using System;

namespace BotCommon.Commands.Exceptions;

/// <summary>
/// Multi-action command started exception.
/// </summary>
public class MultiActionCommandNotStartedException : Exception
{
  /// <summary>
  /// Constructor.
  /// </summary>
  /// <param name="message">Exception message.</param>
  public MultiActionCommandNotStartedException(string message) : base(message){ }
}