using Evidentia.Domain.Commands;
using Evidentia.Domain.Models;

namespace Evidentia.CaseService.Contracts;

public interface ICaseGrain : IGrainWithGuidKey
{
  Task<Case> GetAsync();
  Task<Case> CreateAsync(string title, string clientName);
  Task<Case> ExecuteCommandAsync(CaseCommand command);
}