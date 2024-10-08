﻿using System.Collections.Generic;

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
  private readonly Dictionary<long, UserContexts.UserContext> _userContexts = new();

  #endregion

  #region Methods

  /// <summary>
  /// Get or create context for user.
  /// </summary>
  /// <param name="userId">Bot user ID.</param>
  /// <returns>Created or found user context.</returns>
  public UserContexts.UserContext GetOrCreateUserContext(long userId)
  {
    if (!_userContexts.ContainsKey(userId)) _userContexts[userId] = new UserContexts.UserContext(userId);
    return _userContexts[userId];
  }

  /// <summary>
  /// Remove user context.
  /// </summary>
  /// <param name="userId">Bot user ID.</param>
  public void RemoveUserContext(long userId)
  {
    if (_userContexts.ContainsKey(userId)) _userContexts.Remove(userId);
  }

  #endregion
}