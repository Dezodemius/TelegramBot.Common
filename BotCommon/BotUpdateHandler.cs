using System;
using System.Threading;
using System.Threading.Tasks;
using BotCommon.Repository;
using BotCommon.Scenarios;
using Newtonsoft.Json;
using NLog;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace BotCommon;

public abstract class BotUpdateHandler : IUpdateHandler
{
  protected static readonly ILogger log = LogManager.GetCurrentClassLogger();
  protected static UserScenarioRepository _userScenarioRepository;
  protected static ActiveUsersManager _activeUsersManager;
  protected static BotConfigManager _configManager;

  protected abstract void HandleUpdate(ITelegramBotClient bot, Update update, ref UserCommandScenario scenario,
    CancellationToken cancellationToken);

  public async Task HandleUpdateAsync(ITelegramBotClient bot, Update update, CancellationToken cancellationToken)
  {
    log.Info(JsonConvert.SerializeObject(update));
    var userId = GetUserId(update);
    if (userId == default)
      return;

    _activeUsersManager.Add(new BotUser(userId));
    UserCommandScenario userScenario = null;

    this.HandleUpdate(bot, update, ref userScenario, cancellationToken);

    if (userScenario == null && _userScenarioRepository.TryGet(userId, out var _userScenario))
      userScenario = _userScenario;
    else
      _userScenarioRepository.AddOrReplace(userScenario);

    if (userScenario != null && !(await userScenario.Run(bot, update, userId)))
      _userScenarioRepository.Remove(userScenario);
  }

  public async Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
  {
    LogManager.GetCurrentClassLogger().Error(exception);
    try
    {
      foreach (var botAdmin in _configManager.Config.BotAdminId)
        await botClient.SendTextMessageAsync(botAdmin, "Бот упал", cancellationToken: cancellationToken);
    }
    catch (Exception e)
    {
      log.Error(e);
    }
    finally
    {
      Environment.Exit(1);
    }
  }

  protected virtual long GetUserId(Update update)
  {
    return update.Type switch
    {
        UpdateType.Message => update.Message.From.Id,
        UpdateType.CallbackQuery => update.CallbackQuery.From.Id,
        _ => default
    };
  }

  protected virtual string GetMessage(Update update)
  {
    return update.Type switch
    {
        UpdateType.Message => update.Message.Text,
        UpdateType.CallbackQuery => update.CallbackQuery.Data,
        _ => null
    };
  }

  public BotUpdateHandler()
  {
    _configManager = new BotConfigManager();
    _userScenarioRepository = new UserScenarioRepository();
    _activeUsersManager = new ActiveUsersManager(_configManager.Config.DbConnectionString);
  }
}