﻿using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BotCommon.Scenarios;

public class LongCommand
{
  #region Methods

  /// <summary>
  ///   Run command.
  /// </summary>
  /// <param name="botClient">Telegram bot client.</param>
  /// <param name="update">Telegram chat update.</param>
  /// <param name="chatId">Telegram user ID.</param>
  /// <returns><c>True</c> if command executed.</returns>
  public async Task<bool> Run(ITelegramBotClient botClient, Update update, long chatId)
  {
    return await LongCommandHandler.ExecuteLongCommandStep(botClient, update, chatId);
  }

  #endregion

  #region Fields & props

  /// <summary>
  ///   Telegram user ID.
  /// </summary>
  public long UserId { get; set; }

  /// <summary>
  ///   Command ID.
  /// </summary>
  public Guid CommandId { get; set; }

  /// <summary>
  ///   Long command handler.
  /// </summary>
  public BotLongCommandHandler LongCommandHandler { get; set; }

  #endregion

  #region Constructors

  /// <summary>
  ///   Constructor.
  /// </summary>
  public LongCommand()
  {
  }

  /// <summary>
  ///   Constructor.
  /// </summary>
  /// <param name="userId">Telegram user ID.</param>
  /// <param name="longCommandHandler">Long command handler.</param>
  public LongCommand(long userId, BotLongCommandHandler longCommandHandler)
  {
    UserId = userId;
    LongCommandHandler = longCommandHandler;
    CommandId = longCommandHandler.Id;
  }

  #endregion
}