namespace Evidentia.Domain.Models;

public class Organization
{
  public Guid Id { get; set; } = Guid.NewGuid();
  public string Name { get; set; } = string.Empty;
  public List<Guid> RepresentativeIds { get; set; } = [];
}