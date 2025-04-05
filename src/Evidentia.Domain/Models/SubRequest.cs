namespace Evidentia.Domain.Models;

public class SubRequest
{
  public Guid Id { get; set; } = Guid.NewGuid();
  public string Target { get; set; } = string.Empty; // Who/where to request from
  public string EvidenceType { get; set; } = string.Empty;
  public bool Completed { get; set; } = false;
}