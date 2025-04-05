namespace Evidentia.Domain.Models;

public class Request
{
  public Guid Id { get; set; } = Guid.NewGuid();
  public string Description { get; set; } = string.Empty;
  public RequestType Type { get; set; }
  public List<SubRequest> SubRequests { get; set; } = [];
  public string Status { get; set; } = "InProgress"; // Or use enum
}