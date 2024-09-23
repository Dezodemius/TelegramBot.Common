using System.Collections.Generic;
using BotCommon.Commands;

namespace BotCommon.UserContexts;

/// <summary>
/// User context.
/// </summary>
public class UserContext
{
  #region Fields and props

  /// <summary>
  /// Bot user ID.
  /// </summary>
  public long UserId { get; }

  /// <summary>
  /// Bot command context.
  /// </summary>
  public BaseCommand Command { get; set; }
  
  /// <summary>
  /// Current index of command action.
  /// </summary>
  public int CurrentCommandIndex { get; set; }

  /// <summary>
  /// User context parameters.
  /// </summary>
  public Dictionary<string, object> Parameters { get; } = new();

  /// <summary>
  /// Is user has active command.
  /// </summary>
  public bool HasActiveCommand => Command is { IsCompleted: false };

  #endregion

  #region MyRegion

  /// <summary>
  /// Constructor.
  /// </summary>
  /// <param name="userId">Bot user ID.</param>
  public UserContext(long userId)
  {
    UserId = userId;
  }
  
  #endregion
}