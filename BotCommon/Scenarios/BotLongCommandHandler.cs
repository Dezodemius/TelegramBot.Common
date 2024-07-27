using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BotCommon.Scenarios;

/// <summary>
/// Bot long command handler.
/// </summary>
/// <remarks>
/// Long command is non single message command in telegram bot.
/// Each subcommand in sequence processed individually for every user.</remarks>
public abstract class BotLongCommandHandler
{
  #region Fields & props

  /// <summary>
  /// Command ID.
  /// </summary>
  public abstract Guid Id { get; }

  /// <summary>
  /// Long command name.
  /// </summary>
  public abstract string LongCommand { get; }

  /// <summary>
  /// Current command step.
  /// </summary>
  protected BotLongCommandStep _currentStep;

  /// <summary>
  /// All long command steps.
  /// </summary>
  protected IEnumerator<BotLongCommandStep> _steps;

  #endregion

  #region Methods

  /// <summary>
  /// Execute long command step.
  /// </summary>
  /// <param name="telegramBotClient">Telegram bot client.</param>
  /// <param name="update">Telegram bot update.</param>
  /// <param name="chatId">Telegram chat ID.</param>
  /// <returns>True, if step executed.</returns>
  public virtual async Task<bool> ExecuteLongCommandStep(ITelegramBotClient telegramBotClient, Update update, long chatId)
  {
    var canExecute = this._currentStep != null;
    if (canExecute)
      await this._currentStep.StepAction(telegramBotClient, update, chatId)!;
    return canExecute;
  }

  /// <summary>
  /// Reset steps sequence to start.
  /// </summary>
  public virtual void Reset()
  {
    this._steps.Reset();
    this._currentStep = this._steps.Current;
  }

  #endregion
}