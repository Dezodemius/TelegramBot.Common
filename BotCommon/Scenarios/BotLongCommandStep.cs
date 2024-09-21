using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BotCommon.Scenarios;

/// <summary>
///   Long command step.
/// </summary>
public class BotLongCommandStep
{
  #region Fields & props

  /// <summary>
  ///   Step action delegate.
  /// </summary>
  public delegate Task StepActionType(ITelegramBotClient bot, Update update, long chatId);

  /// <summary>
  ///   Step action.
  /// </summary>
  public StepActionType StepAction { get; }

  #endregion

  #region Constructors

  /// <summary>
  ///   Constructor.
  /// </summary>
  public BotLongCommandStep()
  {
  }

  /// <summary>
  ///   Constructor.
  /// </summary>
  /// <param name="stepAction">Step action.</param>
  public BotLongCommandStep(StepActionType stepAction)
  {
    StepAction = stepAction;
  }

  #endregion
}