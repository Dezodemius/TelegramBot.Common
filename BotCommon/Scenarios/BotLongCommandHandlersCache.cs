using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BotCommon.Scenarios;

/// <summary>
///   Bot long command cache.
/// </summary>
public static class BotLongCommandHandlersCache
{
  #region Fields & props

  private static readonly IDictionary<long, BotLongCommandHandler> _longCommandHandlers
    = new Dictionary<long, BotLongCommandHandler>();

  /// <summary>
  ///   Long command handlers cache.
  /// </summary>
  public static ReadOnlyDictionary<long, BotLongCommandHandler> LongCommandHandlers
    => _longCommandHandlers.AsReadOnly();

  #endregion

  #region Methods

  /// <summary>
  ///   Find command by name and user ID.
  /// </summary>
  /// <param name="userId">Telegram bot user ID.</param>
  /// <param name="commandName">Command name to find.</param>
  /// <returns>Pair of user ID and found long command handler.</returns>
  public static KeyValuePair<long, BotLongCommandHandler> Find(long userId, string commandName)
  {
    return _longCommandHandlers
      .SingleOrDefault(s => s.Key == userId && s.Value.LongCommand == commandName);
  }

  /// <summary>
  ///   Add command to cache.
  /// </summary>
  /// <param name="userId">Telegram bot user ID.</param>
  /// <param name="commandHandler">Long command handler.</param>
  public static void Add(long userId, BotLongCommandHandler commandHandler)
  {
    if (_longCommandHandlers.All(s => s.Key == userId && s.Value.Id != commandHandler.Id))
      _longCommandHandlers.Add(new KeyValuePair<long, BotLongCommandHandler>(userId, commandHandler));
  }

  /// <summary>
  ///   Remove command from cache by command ID.
  /// </summary>
  /// <param name="userId">Telegram bot user ID.</param>
  /// <param name="commandId">Long command handler ID.</param>
  public static void Remove(long userId, Guid commandId)
  {
    var commandHandlerToRemove = Get(userId, commandId);
    _longCommandHandlers.Remove(commandHandlerToRemove);
  }

  /// <summary>
  ///   Remove command from cache.
  /// </summary>
  /// <param name="userId">Telegram bot user ID.</param>
  /// <param name="longCommandHandler">Long command handler.</param>
  public static void Remove(long userId, BotLongCommandHandler longCommandHandler)
  {
    var commandHandlerToRemove = Get(userId, longCommandHandler.Id);
    _longCommandHandlers.Remove(commandHandlerToRemove);
  }

  /// <summary>
  ///   Get long command handler from cache.
  /// </summary>
  /// <param name="userId">Telegram bot user ID.</param>
  /// <param name="longCommandHandlerId">Long command handler ID.</param>
  /// <returns></returns>
  private static KeyValuePair<long, BotLongCommandHandler> Get(long userId, Guid longCommandHandlerId)
  {
    return _longCommandHandlers
      .SingleOrDefault(s => s.Key == userId && s.Value.Id == longCommandHandlerId);
  }

  #endregion
}