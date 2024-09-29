using System;

namespace BotCommon.Commands.Exceptions;

/// <summary>
/// Multi-action command is null exception.
/// </summary>
public class MultiActionCommandNullException : Exception
{
  /// <summary>
  /// Constructor.
  /// </summary>
  /// <param name="message">Exception message.</param>
  public MultiActionCommandNullException(string message) : base(message){ }
}