using System;

namespace BotCommon.Commands.Exceptions;

/// <summary>
/// Command has no end exception.
/// </summary>
public class CommandHasNoEndException : Exception
{
  /// <summary>
  /// Constructor.
  /// </summary>
  /// <param name="message">Exception message.</param>
  public CommandHasNoEndException(string message) : base(message){ }  
}