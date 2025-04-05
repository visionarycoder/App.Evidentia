namespace Evidentia.Domain.Models;

public class Case
{
  public Guid Id { get; set; } = Guid.NewGuid();
  public string Title { get; set; } = string.Empty;
  public string ClientName { get; set; } = string.Empty;
  public CaseState State { get; set; } = CaseState.Unsubmitted;
  public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
}