namespace Evidentia.Domain.Models;

[Flags]
public enum RequestType
{
  Subpoena = 1,
  Authorization = 2,
}