using System.Net;

namespace Evidentia.Domain.Commands;

public class CaseCommand
{
  public string Action { get; set; } = string.Empty;
  public Dictionary<string, object>? Parameters { get; set; }
}