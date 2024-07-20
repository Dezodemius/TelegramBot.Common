using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BotCommon.Broadcast;

/// <summary>
/// User of broadcast message.
/// </summary>
/// <param name="UserId">Telegram user ID.</param>
/// <param name="BroadcastTime">Broadcast time.</param>
/// <param name="IsMessageSent">Flag is message sent.</param>
/// <param name="IsBotBlocked">Flag is user block bot.</param>
public record BroadcastMessageUser(long UserId, DateTime BroadcastTime, bool IsMessageSent, bool IsBotBlocked)
{
  /// <summary>
  /// User ID.
  /// </summary>
  [Key]
  public int Id { get; set; }
  
  /// <summary>
  /// Flag is user block bot.
  /// </summary>
  public bool IsBotBlocked { get; set; } = IsBotBlocked;
  
  /// <summary>
  /// Flag is message sent.
  /// </summary>
  public bool IsMessageSent { get; set; } = IsMessageSent;
  
  /// <summary>
  /// Broadcast time.
  /// </summary>
  public DateTime BroadcastTime { get; set; } = BroadcastTime;
  
  /// <summary>
  /// Telegram user ID.
  /// </summary>
  public long UserId { get; set; } = UserId;
}