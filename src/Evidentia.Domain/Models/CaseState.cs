namespace Evidentia.Domain.Models;

public enum CaseState
{
  Unsubmitted,
  NewRequest,
  InProcess,
  EFilings,
  Received,
  FirstLook,
  OnHold,
  Cancelled,
  Closed
}