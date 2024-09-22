using Telegram.Bot;

namespace BotCommon.Command;

/// <summary>
/// Command arguments.
/// </summary>
public class CommandArgs
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

  /// <summary>
  /// User context.
  /// </summary>
  public UserContext.UserContext UserContext { get; }

  #endregion

  #region Constructors

  /// <summary>
  /// Constructor.
  /// </summary>
  /// <param name="chatId">Bot user ID.</param>
  /// <param name="botClient">Telegram bot client.</param>
  /// <param name="userContext">Bot user context.</param>
  public CommandArgs(long chatId, ITelegramBotClient botClient, UserContext.UserContext userContext)
  {
    this.ChatId = chatId;
    this.BotClient = botClient;
    this.UserContext = userContext;
  }

  #endregion
}