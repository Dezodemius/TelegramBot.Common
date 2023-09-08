using System;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NLog;
using Telegram.Bot;
using Telegram.Bot.Polling;

namespace BotCommon;

public static class BotRunner
{
  private static readonly ILogger log = LogManager.GetCurrentClassLogger();

  public static void Run<T>(string botToken, ReceiverOptions botOptions, CancellationToken cancellationToken)
      where T : BotUpdateHandler, new()
  {
    var bot = new TelegramBotClient(botToken);
    bot.OnApiResponseReceived += (_, args, _) =>
    {
      log.Debug($" <<<< {JsonConvert.SerializeObject(args)}");
      return ValueTask.CompletedTask;
    };
    bot.OnMakingApiRequest += (_, args, _) =>
    {
      log.Debug($" >>>> {JsonConvert.SerializeObject(args)}");
      return ValueTask.CompletedTask;
    };
    var updateHandler = new T();
    bot.StartReceiving(
      updateHandler: updateHandler.HandleUpdateAsync,
      pollingErrorHandler: updateHandler.HandlePollingErrorAsync,
      receiverOptions: botOptions,
      cancellationToken: cancellationToken);
    string command;
    do
    {
      command = Console.ReadLine();
    } while (!command.Equals("/exit", StringComparison.InvariantCulture));
    log.Info("Bye bye");
    Environment.Exit(0);
  }
}