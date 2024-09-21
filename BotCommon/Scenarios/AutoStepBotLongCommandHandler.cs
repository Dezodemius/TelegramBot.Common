using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BotCommon.Scenarios;

/// <summary>
///   Auto step command command handler.
/// </summary>
/// <remarks></remarks>
public abstract class AutoStepBotLongCommandHandler
  : BotLongCommandHandler
{
  #region Base

  public override async Task<bool> ExecuteLongCommandStep(ITelegramBotClient telegramBotClient, Update update,
    long chatId)
  {
    if (!_steps.MoveNext())
      return false;

    _currentStep = _steps.Current;
    return await base.ExecuteLongCommandStep(telegramBotClient, update, chatId);
  }

  #endregion
}