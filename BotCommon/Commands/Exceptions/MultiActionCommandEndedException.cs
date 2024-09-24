using System;

namespace BotCommon.Commands.Exceptions;

/// <summary>
/// Multi-action command ended exception.
/// </summary>
public class MultiActionCommandEndedException : Exception
{
  /// <summary>
  /// Constructor.
  /// </summary>
  /// <param name="message">Exception message.</param>
  public MultiActionCommandEndedException(string message) : base(message){ }
}