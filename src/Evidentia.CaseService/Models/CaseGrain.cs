using System.Text.Json;
using Evidentia.CaseService.Contracts;
using Evidentia.Domain.Commands;
using Evidentia.Domain.Models;
using Evidentia.Rules;
using Microsoft.Extensions.Logging;
using RulesEngine.Models;

namespace Evidentia.CaseService.Models;

public class CaseGrain(ILogger<CaseGrain> logger) : Grain, ICaseGrain
{

  private readonly Action<string, object[]> logDebug = logger.LogDebug;
  private readonly Action<string, object[]> logInformation = logger.LogInformation;
  private readonly Action<string, object[]> logWarning = logger.LogWarning;

  private Case @case = new();
  private RulesEngine.RulesEngine rulesEngine = null!; // Initialized in OnActivateAsync

  // Delegates for logging actions
  
  public Task<Case> GetAsync()
  {
    logDebug("Retrieving case {CaseId}", [@case.Id]);
    return Task.FromResult(@case);
  }

  public Task<Case> CreateAsync(string title, string clientName)
  {
    @case = new Case
    {
      Id = this.GetPrimaryKey(),
      Title = title,
      ClientName = clientName,
      State = CaseState.Unsubmitted,
      CreatedUtc = DateTime.UtcNow
    };

    logInformation("Created case {CaseId} for client {Client}", [@case.Id, @case.ClientName]);

    return Task.FromResult(@case);
  }

  public override Task OnActivateAsync(CancellationToken cancellationToken)
  {
    var json = File.ReadAllText("rules.json"); // Replace with proper path later
    var workflows = JsonSerializer.Deserialize<Workflow[]>(json)!;
    rulesEngine = new RulesEngine.RulesEngine(workflows.ToArray(), null);

    return base.OnActivateAsync(cancellationToken);
  }

  public async Task<Case> ExecuteCommandAsync(CaseCommand command)
  {

    logInformation("Executing command {Action} for case {CaseId}", [command.Action, @case.Id]);

    var input = new RuleContext
    {
      Action = command.Action,
      CurrentState = @case.State.ToString()
    };

    var result = await rulesEngine!.ExecuteAllRulesAsync("CaseStateWorkflow", input);

    if(!result.First().IsSuccess)
    {
      logWarning("Transition not allowed: {Error}", [result.First().ExceptionMessage]);
      return @case;
    }

    logInformation("RulesEngine approved transition: {Action}", [command.Action]);
    @case.State = GetNextState(command.Action,@case.State);
    return @case;
  }

  private CaseState GetNextState(string action, CaseState current)
  {
    return action switch
    {
      "Submit" when current == CaseState.Unsubmitted => CaseState.NewRequest,
      "StartProcessing" when current == CaseState.NewRequest => CaseState.InProcess,
      "Close" => CaseState.Closed,
      _ => current
    };
  }
}