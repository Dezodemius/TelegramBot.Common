using System.Collections.Generic;
using BotCommon.Commands;
using Telegram.Bot.Types;

namespace BotCommon.UserContexts;

/// <summary>
/// User context.
/// </summary>
public class UserContext
{
  #region Fields and props

  /// <summary>
  /// Bot user.
  /// </summary>
  public User User { get; }

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

  #region Constructors

  /// <summary>
  /// Constructor.
  /// </summary>
  /// <param name="user">Bot user.</param>
  public UserContext(User user)
  {
    User = user;
  }
  
  #endregion
}