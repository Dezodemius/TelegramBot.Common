using Telegram.Bot;

var botClient = new TelegramBotClient("6561412539:AAHnKqUA1gG1RwY0lbK75CzK9kyspFwZvMc");

// Устанавливаем URL вебхука
await botClient.SetWebhookAsync("https://2f7a-45-159-250-211.ngrok-free.app/botupdate");
Console.ReadKey();