using System;
using System.Collections.Generic;
using BotCommon.UserContexts;

namespace BotCommon.Commands;

/// <summary>
/// Bot multi-action command.
/// </summary>
public class MultiActionCommand : BaseCommand
{
  #region Methods

  /// <summary>
  /// Start command with action.
  /// </summary>
  /// <param name="action">Action to execute on start.</param>
  /// <returns>Current command.</returns>
  public MultiActionCommand StartWith(StepAction action)
  {
    this.ThrowOnCommandAlreadyStarted();

    this._stepActions = new List<StepAction> { action };

    return this;
  }

  /// <summary>
  /// Add next action in command.
  /// </summary>
  /// <param name="action">Adding action.</param>
  /// <returns>Current command.</returns>
  public MultiActionCommand Then(StepAction action)
  {
    this.ThrowOnCommandNotStarted();
    this.ThrowOnCommandIsCompleted();
    
    this._stepActions.Add(action);

    return this;
  }

  /// <summary>
  /// Add next action with condition.
  /// </summary>
  /// <param name="stepAction">Adding action.</param>
  /// <param name="condition">Condition of action</param>
  /// <returns>Current command.</returns>
  public MultiActionCommand ThenOnCondition(StepAction stepAction, Func<UserContext, CommandArgs, bool> condition)
  {
    this.ThrowOnCommandNotStarted();
    this.ThrowOnCommandIsCompleted();
    
    this._stepActions.Add((context, args) =>
    {
      if (condition(context, args))
        stepAction(context, args);
    });

    return this;
  }

  /// <summary>
  /// Complete command after action.
  /// </summary>
  /// <param name="stepAction">Action to execute.</param>
  /// <returns>Current command.</returns>
  public MultiActionCommand CompleteAfter(StepAction stepAction)
  {
    this.ThrowOnCommandNotStarted();
    this.ThrowOnCommandIsCompleted();

    this._stepActions.Add((context, args) =>
    {
      stepAction(context, args);
      this.IsCompleted = true;
    });

    return this;
  }
  
  /// <summary>
  /// Complete command.
  /// </summary>
  /// <returns>Current command.</returns>
  public MultiActionCommand Complete()
  {
    this.ThrowOnCommandNotStarted();
    this.ThrowOnCommandIsCompleted();

    this._stepActions.Add((_, _) =>
    {
      this.IsCompleted = true;
    });
    
    return this;
  }

  /// <summary>
  /// Throws exception if command not started.
  /// </summary>
  /// <exception cref="InvalidOperationException">Throws if command not started with <see cref="StartWith"/>.</exception>
  private void ThrowOnCommandNotStarted()
  {
    if (this._stepActions == null)
      throw new InvalidOperationException($"Use {nameof(StartWith)} to start the command");
  }

  /// <summary>
  /// Throws exception if command already started.
  /// </summary>
  /// <exception cref="InvalidOperationException">Throws if command already started with <see cref="StartWith"/>.</exception>
  private void ThrowOnCommandAlreadyStarted()
  {
    if (this._stepActions != null)
      throw new InvalidOperationException("Command already started");
  }
  
  /// <summary>
  /// Throws exception if command already completed.
  /// </summary>
  /// <exception cref="InvalidOperationException">Throws if command completed.</exception>
  private void ThrowOnCommandIsCompleted()
  {
    if (this.IsCompleted)
      throw new InvalidOperationException("Command is already completed");
  }

  #endregion

  #region Constructors

  /// <summary>
  /// Constructor.
  /// </summary>
  /// <param name="commandName">Name of command.</param>
  public MultiActionCommand(string commandName) : base(commandName) { }

  #endregion
}