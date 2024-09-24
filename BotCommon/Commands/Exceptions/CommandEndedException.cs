using System;

namespace BotCommon.Commands.Exceptions;

/// <summary>
/// Command ended exception.
/// </summary>
public class CommandEndedException : Exception
{
  /// <summary>
  /// Constructor.
  /// </summary>
  /// <param name="message">Exception message.</param>
  public CommandEndedException(string message) : base(message){ }
}