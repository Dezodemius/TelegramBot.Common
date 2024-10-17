using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;

namespace TelegramBot.BaseBot;

public class TelegramBotRunner
{
  private UpdateType[] _allowedUpdates;

  public void BulkAddAllowedUpdates(params UpdateType[] allowedUpdates)
  {
    _allowedUpdates = allowedUpdates;    
  }
  
  public ITelegramBotClient RunBot(string botToken, IUpdateHandler updateHandler)
  {
    if (_allowedUpdates is null)
      throw new InvalidOperationException("Cannot run bot without any allowed updates configured");

    var bot = GetConfigureBot(botToken);

    bot.StartReceiving(updateHandler.HandleUpdateAsync, updateHandler.HandlePollingErrorAsync) ;

    return bot;
  }

  protected virtual TelegramBotClient GetConfigureBot(string botToken)
  {
    var options = new TelegramBotClientOptions(botToken);
    var bot = new TelegramBotClient(options);
    var receiverOptions = new ReceiverOptions();
    receiverOptions.AllowedUpdates = _allowedUpdates;
    return bot;
  }
}