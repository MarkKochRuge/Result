using System;

namespace Result.Interfaces;

public interface IReason
{
  public Exception? Exception { get; }
}
