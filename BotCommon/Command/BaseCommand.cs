using System.Collections.Generic;

namespace BotCommon.Command;

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
  public delegate void StepAction(CommandArgs args);
  
  /// <summary>
  /// Steps of the command.
  /// </summary>
  protected ICollection<StepAction> _stepActions;

  #endregion

  #region Constructors

  /// <summary>
  /// Constructor.
  /// </summary>
  /// <param name="commandName">Name of command.</param>
  protected BaseCommand(string commandName)
  {
    this.CommandName = commandName;
  }

  #endregion
}