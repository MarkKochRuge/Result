using System;
using System.Collections.Generic;
using Result.Interfaces;

namespace Result.Models;

public class Reason : IReason
{
  private Exception? _exception;

  public Exception? Exception => _exception;
  public Dictionary<object, object> Extensions { get; set; } = [];

  public Reason(Exception exception)
  {
    _exception = Exception;
  }
}
