using System;

namespace BotCommon.Commands.Exceptions;

/// <summary>
/// Multi-action command has no end exception.
/// </summary>
public class MultiActionCommandHasNoEndException : Exception
{
  /// <summary>
  /// Constructor.
  /// </summary>
  /// <param name="message">Exception message.</param>
  public MultiActionCommandHasNoEndException(string message) : base(message){ }  
}