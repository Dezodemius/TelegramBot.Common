using System;

namespace BotCommon.Commands.Exceptions;

/// <summary>
/// Command started exception.
/// </summary>
public class CommandStartedException : Exception
{
  /// <summary>
  /// Constructor.
  /// </summary>
  /// <param name="message">Exception message.</param>
  public CommandStartedException(string message) : base(message){ }
}