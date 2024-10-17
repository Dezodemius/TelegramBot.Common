using BotCommon;
using BotCommon.Commands;
using BotCommon.UserContexts;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace TelegramBot.BaseBot;

public abstract class BaseUpdateHandler : IUpdateHandler
{
  protected UserContextManager UserContextManager { get; set; }
  
  protected IDictionary<string, BaseCommand> Commands { get; set; }

  public virtual Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
  {
    var userContext = this.UserContextManager.GetOrCreateUserContext(BotHelper.GetUserInfo(update));
    var command = this.Commands[BotHelper.GetMessage(update)];
    command.ExecuteCommand(userContext, new CommandArgs(BotHelper.GetUserInfo(update).Id, botClient, update), cancellationToken);
    
    return Task.CompletedTask;
  }

  public virtual Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }

  public BaseUpdateHandler(UserContextManager userContextManager, IDictionary<string, BaseCommand> commands)
  {
    this.UserContextManager = userContextManager;
    this.Commands = commands;
  }
}