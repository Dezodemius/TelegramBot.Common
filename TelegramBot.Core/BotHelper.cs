using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace BotCommon;

/// <summary>
///   Telegram bot helper.
/// </summary>
public static class BotHelper
{
  /// <summary>
  ///   Get info about telegram user.
  /// </summary>
  /// <remarks>
  ///   User info extracts from update of type <see cref="UpdateType.Message" /> or <see cref="UpdateType.CallbackQuery" />.
  ///   If the type does not match, the <c>default</c> value is returned.
  /// </remarks>
  /// <param name="update">Update containing info about user.</param>
  /// <returns>Telegram user.</returns>
  public static User GetUserInfo(Update update)
  {
    return update.Type switch
    {
      UpdateType.Message => update.Message?.From,
      UpdateType.CallbackQuery => update.CallbackQuery?.From,
      _ => default
    };
  }

  /// <summary>
  ///   Get username.
  /// </summary>
  /// <param name="update">Update containing info about user.</param>
  /// <returns>Username.</returns>
  public static string GetUsername(Update update)
  {
    return GetUsername(GetUserInfo(update));
  }

  /// <summary>
  ///   Get username.
  /// </summary>
  /// <param name="user">Telegram user.</param>
  /// <returns>Username.</returns>
  public static string GetUsername(User user)
  {
    return string.IsNullOrEmpty(user.Username)
      ? $"{user.FirstName} {user.LastName}"
      : user.Username;
  }

  /// <summary>
  ///   Get message.
  /// </summary>
  /// ///
  /// <remarks>
  ///   Message extracts from update of type <see cref="UpdateType.Message" /> or <see cref="UpdateType.CallbackQuery" />.
  ///   If the type does not match, the <c>default</c> value is returned.
  /// </remarks>
  /// <param name="update">Update containing message.</param>
  /// <returns>Message.</returns>
  public static string GetMessage(Update update)
  {
    return update.Type switch
    {
      UpdateType.Message => update.Message?.Text,
      UpdateType.CallbackQuery => update.CallbackQuery?.Data,
      _ => null
    };
  }
}