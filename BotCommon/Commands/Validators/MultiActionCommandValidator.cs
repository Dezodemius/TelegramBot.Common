using BotCommon.Commands.Exceptions;

namespace BotCommon.Commands.Validators;

/// <summary>
/// Multi action command validator.
/// </summary>
public static class MultiActionCommandValidator
{
  /// <summary>
  /// Validate command.
  /// </summary>
  /// <param name="command">Command to validate.</param>
  public static void Validate(MultiActionCommand command)
  {
    ThrowOnCommandIsNull(command);
    ThrowOnCommandNotStarted(command);
    ThrowOnCommandIsCompleted(command);
    ThrowOnCommandHasNoEnd(command);
  }

  /// <summary>
  /// Throws exception if command is null.
  /// </summary>
  /// <param name="command">Command to check.</param>
  /// <exception cref="MultiActionCommandNullException">Throws if command is null.</exception>
  private static void ThrowOnCommandIsNull(MultiActionCommand command)
  {
    if (command is null)
      throw new MultiActionCommandNullException("Command cannot be null");
  }

  /// <summary>
  /// Throws exception if command has no ended actions.
  /// </summary>
  /// <param name="command">Command to check.</param>
  /// <exception cref="MultiActionCommandHasNoEndException">Throws if command has no ended actions.</exception>
  private static void ThrowOnCommandHasNoEnd(MultiActionCommand command)
  {
    if (!command.HasEnd)
      throw new MultiActionCommandHasNoEndException("Command has no end");
  }
  
  /// <summary>
  /// Throws exception if command already completed.
  /// </summary>
  /// <exception cref="MultiActionCommandEndedException">Throws if command completed.</exception>
  private static void ThrowOnCommandIsCompleted(MultiActionCommand command)
  {
    if (command.IsCompleted)
      throw new MultiActionCommandEndedException("Command completed");
  }

  /// <summary>
  /// Throws exception if command not started.
  /// </summary>
  /// <exception cref="MultiActionCommandNotStartedException">Throws if command not started with <see cref="MultiActionCommand.StartWith"/>.</exception>
  private static void ThrowOnCommandNotStarted(MultiActionCommand command)
  {
    if (!command.HasStart)
      throw new MultiActionCommandNotStartedException($"Use {nameof(command.StartWith)} to start the command");
  }
}