using System;
using System.Collections.Generic;
using BotCommon.Commands.Exceptions;
using BotCommon.UserContexts;

namespace BotCommon.Commands;

/// <summary>
/// Bot multi-action command.
/// </summary>
public class MultiActionCommand : BaseCommand
{
  #region Fields and props

  /// <summary>
  /// A sign that a command has start.
  /// </summary>
  internal bool HasStart { get; private set; }
  
  /// <summary>
  /// A sign that a command has an end.
  /// </summary>
  internal bool HasEnd { get; private set; }

  #endregion
  
  #region Methods

  /// <summary>
  /// Start command with action.
  /// </summary>
  /// <param name="action">Action to execute on start.</param>
  /// <returns>Current command.</returns>
  public MultiActionCommand StartWith(StepAction action)
  {
    if (this.HasStart)
      throw new CommandStartedException("Command already started");

    this.HasStart = true;

    this._stepActions.Add(action);

    return this;
  }

  /// <summary>
  /// Add next action in command.
  /// </summary>
  /// <param name="action">Adding action.</param>
  /// <returns>Current command.</returns>
  public MultiActionCommand Then(StepAction action)
  {
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
    this._stepActions.Add((context, args) =>
    {
      if (condition(context, args))
        stepAction(context, args);
    });

    return this;
  }

  /// <summary>
  /// End command after action.
  /// </summary>
  /// <param name="stepAction">Action to execute.</param>
  /// <returns>Current command.</returns>
  public MultiActionCommand EndAfter(StepAction stepAction)
  {
    if (this.HasEnd)
      throw new CommandEndedException("Command already ended");

    this._stepActions.Add((context, args) =>
    {
      stepAction(context, args);
      this.IsCompleted = true;
    });

    this.HasEnd = true;
    
    return this;
  }
  
  /// <summary>
  /// End command.
  /// </summary>
  /// <returns>Current command.</returns>
  public MultiActionCommand End()
  {
    if (this.HasEnd)
      throw new CommandEndedException("Command already ended");

    this._stepActions.Add((_, _) =>
    {
      this.IsCompleted = true;
    });
    
    this.HasEnd = true;
    
    return this;
  }

  #endregion

  #region Constructors

  /// <summary>
  /// Constructor.
  /// </summary>
  /// <param name="commandName">Name of command.</param>
  public MultiActionCommand(string commandName) : base(commandName)
  {
    this._stepActions = new List<StepAction>();
  }

  #endregion
}