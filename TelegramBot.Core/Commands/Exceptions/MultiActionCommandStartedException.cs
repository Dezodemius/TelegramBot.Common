using System;

namespace BotCommon.Commands.Exceptions;

/// <summary>
/// Multi-action command started exception.
/// </summary>
public class MultiActionCommandStartedException : Exception
{
  /// <summary>
  /// Constructor.
  /// </summary>
  /// <param name="message">Exception message.</param>
  public MultiActionCommandStartedException(string message) : base(message){ }
}