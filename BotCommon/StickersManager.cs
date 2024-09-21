using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BotCommon;

/// <summary>
///   Telegram chat sticker manager.
/// </summary>
public static class StickersManager
{
  /// <summary>
  ///   Sticker from pack.
  /// </summary>
  private static Sticker[] _stickers;

  /// <summary>
  ///   Initialize manager by sticker pack.
  /// </summary>
  /// <param name="botClient">Telegram bot client.</param>
  /// <param name="stickerPackName">Sticker pack name.</param>
  public static void InitializeStickerPack(ITelegramBotClient botClient, string stickerPackName)
  {
    _stickers = botClient.GetStickerSetAsync(stickerPackName).Result.Stickers;
  }

  /// <summary>
  ///   Send sticker from sticker pack.
  /// </summary>
  /// <param name="botClient">Telegram bot client.</param>
  /// <param name="chatId">Telegram user chat ID.</param>
  /// <param name="stickerEmoji">Emoji that represents sticker.</param>
  public static async void SendStickerAsync(ITelegramBotClient botClient, long chatId, string stickerEmoji)
  {
    if (_stickers == null)
      return;
    await botClient.SendStickerAsync(chatId, new InputFileId(_stickers.First(x => x.Emoji == stickerEmoji).FileId));
  }
}