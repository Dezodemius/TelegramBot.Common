using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BotCommon.UserContexts;

namespace BotCommon.Commands;

/// <summary>
/// Base bot command.
/// </summary>
public abstract class BaseCommand
{
  #region Fields and props

  /// <summary>
  /// Command name.
  /// </summary>
  public string CommandName { get; }

  /// <summary>
  /// Is command done.
  /// </summary>
  public bool IsCompleted { get; protected set; }

  /// <summary>
  /// Command step action type.
  /// </summary>
  public delegate void StepAction(UserContext context, CommandArgs args);
  
  /// <summary>
  /// Steps of the command.
  /// </summary>
  protected IList<StepAction> _stepActions;

  #endregion

  #region Methods

  public void ExecuteCommand(UserContext context, CommandArgs args, CancellationToken cancellationToken)
  {
    cancellationToken.ThrowIfCancellationRequested();

    var currentStepIndex = context.CurrentCommandIndex;
    var actionToExecute = _stepActions.ElementAt(currentStepIndex);
    actionToExecute?.Invoke(context, args);
    
    context.CurrentCommandIndex++;
  }

  #endregion

  #region Constructors

  /// <summary>
  /// Constructor.
  /// </summary>
  /// <param name="commandName">Name of command.</param>
  protected BaseCommand(string commandName)
  {
    if (string.IsNullOrEmpty(commandName))
      throw new ArgumentNullException(nameof(commandName));

    CommandName = commandName;
  }

  #endregion
}