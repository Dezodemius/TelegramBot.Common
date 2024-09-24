using System;

namespace BotCommon.Commands.Exceptions;

/// <summary>
/// Command started exception.
/// </summary>
public class CommandNotStartedException : Exception
{
  /// <summary>
  /// Constructor.
  /// </summary>
  /// <param name="message">Exception message.</param>
  public CommandNotStartedException(string message) : base(message){ }
}