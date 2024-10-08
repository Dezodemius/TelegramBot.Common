﻿using Telegram.Bot;
using Telegram.Bot.Types;

namespace BotCommon.Commands;

/// <summary>
/// Command arguments.
/// </summary>
public struct CommandArgs
{
  #region Fields and props

  /// <summary>
  /// Telegram chat ID.
  /// </summary>
  public long ChatId { get; }
  
  /// <summary>
  /// Current telegram bot client.
  /// </summary>
  public ITelegramBotClient BotClient { get; }

  #endregion

  #region Constructors

  /// <summary>
  /// Constructor.
  /// </summary>
  /// <param name="chatId">Bot user ID.</param>
  /// <param name="botClient">Telegram bot client.</param>
  /// <param name="update">Bot message update.</param>
  public CommandArgs(long chatId, ITelegramBotClient botClient, Update update)
  {
    this.ChatId = chatId;
    this.BotClient = botClient;
  }

  #endregion
}