using System;

namespace BotCommon.Commands.Exceptions;

/// <summary>
/// Single command already started exception.
/// </summary>
public class SingleActionCommandStartedException : Exception
{
  /// <summary>
  /// Constructor.
  /// </summary>
  /// <param name="message">Exception message.</param>
  public SingleActionCommandStartedException(string message) : base(message){ }
}