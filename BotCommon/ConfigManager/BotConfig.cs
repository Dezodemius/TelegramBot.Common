namespace BotCommon.ConfigManager;

/// <summary>
/// Telegram bot configuration.
/// </summary>
public class BotConfig
{
  /// <summary>
  /// Bot Token.
  /// </summary>
  public string BotToken { get; set; }

  /// <summary>
  /// List of admin ids.
  /// </summary>
  public long[] BotAdminId { get; set; }

  /// <summary>
  /// DB connection string.
  /// </summary>
  public string DbConnectionString { get; set; }
}