using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace BotCommon;

[Route("botupdate")]
[ApiController]
public class BotUpdateController : ControllerBase
{
  private readonly ITelegramBotClient _botClient;

  public BotUpdateController(ITelegramBotClient botClient)
  {
    _botClient = botClient;
  }

  [HttpPost]
  public async Task<IActionResult> Post([FromBody] Update update)
  {
    if (update.Type == UpdateType.Message && update.Message.Type == MessageType.Text)
    {
      var message = update.Message;
      var text = message.Text;

      await HandleMessageAsync(message.Chat.Id, text);
    }

    return Ok();
  }

  private async Task HandleMessageAsync(long chatId, string text)
  {
    // Обработка команд
    if (text.StartsWith("/start"))
    {
      await _botClient.SendTextMessageAsync(chatId, "Welcome! Use /help to see available commands.");
    }
    else if (text.StartsWith("/help"))
    {
      await _botClient.SendTextMessageAsync(chatId,
        "Available commands:\n/start - Start the bot\n/help - Show this help message");
    }
    else if (text.StartsWith("/echo"))
    {
      var commandText = text.Substring("/echo".Length).Trim();
      await _botClient.SendTextMessageAsync(chatId, commandText);
    }
    else
    {
      await _botClient.SendTextMessageAsync(chatId, "Unknown command. Use /help to see available commands.");
    }
  }
}