using System;
using System.Collections.Generic;
using Result.Interfaces;

namespace Result.Models;

public class Result<T>
{
  #region private fields
  private T? _value;

  private List<IError> _errors = [];

  private List<IReason> _reasons = [];
  #endregion

  #region public properties
  public T? Value => _value;

  public bool IsSuccess => _errors.Count == 0;

  public bool IsFailed => !IsSuccess;

  public IEnumerable<IError> Errors => _errors.AsReadOnly();

  public IEnumerable<IReason> Reasons => _reasons;
  #endregion

  public static Result<T> Ok(T? value = default)
  {
    return new Result<T>
    {
      _value = value
    };
  }

  public static Result<T> Fail(string message)
  {
    var error = new Error(message);
    return new Result<T>
    {
      _errors = [error]
    };
  }

  public static Result<T> Fail(IError error)
  {
    return new Result<T>
    {
      _errors = [error]
    };
  }

  public Result<T> WithError(string message)
  {
    var error = new Error(message);
    _errors.Add(error);
    return this;
  }

  public Result<T> WithError(IError error)
  {
    _errors.Add(error);
    return this;
  }

  public Result<T> WithErrors(IEnumerable<IError> errors)
  {
    _errors.AddRange(errors);
    return this;
  }

  public Result<T> WithReason(Exception exception)
  {
    var reason = new Reason(exception);
    _reasons.Add(reason);
    return this;
  }

  public Result<T> WithReason(IReason reason)
  {
    _reasons.Add(reason);
    return this;
  }

  public Result<T> WithReasons(IEnumerable<Reason> reasons)
  {
    _reasons.AddRange(reasons);
    return this;
  }
}
