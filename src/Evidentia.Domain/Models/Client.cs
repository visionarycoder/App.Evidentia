namespace Evidentia.Domain.Models;

public class Client
{
  public Guid Id { get; set; } = Guid.NewGuid();
  public string Name { get; set; } = string.Empty;
  public List<Guid> CaseIds { get; set; } = [];
}