using System;

namespace BotCommon.Commands.Exceptions;

/// <summary>
/// Command is null exception.
/// </summary>
public class CommandNullException : Exception
{
  /// <summary>
  /// Constructor.
  /// </summary>
  /// <param name="message">Exception message.</param>
  public CommandNullException(string message) : base(message){ }
}