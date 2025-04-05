namespace Evidentia.Domain.Models;

public class Individual
{
  public Guid Id { get; set; } = Guid.NewGuid();
  public string FullName { get; set; } = string.Empty;
  public string Role { get; set; } = string.Empty; // Attorney, Paralegal, etc.
  public Guid OrganizationId { get; set; }
}