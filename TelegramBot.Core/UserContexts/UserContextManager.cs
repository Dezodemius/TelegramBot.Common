using System.Collections.Generic;
using Telegram.Bot.Types;

namespace BotCommon.UserContexts;

/// <summary>
/// User context manager.
/// </summary>
public class UserContextManager
{
  #region Fields and props

  /// <summary>
  /// User contexts.
  /// </summary>
  private readonly Dictionary<User, UserContext> _userContexts = new();

  #endregion

  #region Methods

  /// <summary>
  /// Get or create context for user.
  /// </summary>
  /// <param name="userId">Bot user ID.</param>
  /// <returns>Created or found user context.</returns>
  public UserContext GetOrCreateUserContext(User user)
  {
    if (!_userContexts.ContainsKey(user)) _userContexts[user] = new UserContext(user);
    return _userContexts[user];
  }

  /// <summary>
  /// Remove user context.
  /// </summary>
  /// <param name="user">Bot user.</param>
  public void RemoveUserContext(User user)
  {
    if (_userContexts.ContainsKey(user)) _userContexts.Remove(user);
  }

  #endregion
}