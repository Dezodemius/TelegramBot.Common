using System;
using System.Linq;
using BotCommon.Commands.Exceptions;

namespace BotCommon.Commands;

/// <summary>
/// Single bot command.
/// </summary>
public class SingleActionCommand : BaseCommand
{
  #region Methods

  /// <summary>
  /// Perform command with single action.
  /// </summary>
  /// <param name="action">Action of single command.</param>
  /// <returns>Current command.</returns>
  public SingleActionCommand PerformWith(StepAction action)
  {
    this.ThrowIfSingleActionAlreadyAdded();
    
    this._stepActions[0] = action;

    return this;
  }

  /// <summary>
  /// Throws exception if some action already added to command.
  /// </summary>
  /// <exception cref="InvalidOperationException">Throws if some action already added.</exception>
  private void ThrowIfSingleActionAlreadyAdded()
  {
    if (this._stepActions.Any())
      throw new SingleActionCommandStartedException("Command cannot have more than one action.");
  }

  #endregion

  #region Constructors

  /// <summary>
  /// Constructor.
  /// </summary>
  /// <param name="commandName">Name of command.</param>
  public SingleActionCommand(string commandName) : base(commandName)
  {
    this._stepActions = new StepAction[1];
  }

  #endregion
}