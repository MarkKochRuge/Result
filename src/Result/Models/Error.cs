using Result.Interfaces;

namespace Result.Models;

public class Error : IError
{
  public string Message { get; }

  public Error(string message)
  {
    Message = message;
  }
}
