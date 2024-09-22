using System.Collections.Generic;

namespace BotCommon.Command;

/// <summary>
/// User context.
/// </summary>
public class UserContext
{
  #region Fields and props

  /// <summary>
  /// Bot user ID.
  /// </summary>
  public long UserId { get; }

  /// <summary>
  /// Bot command context.
  /// </summary>
  public MultiActionCommand MultiActionCommandContext { get; set; }

  /// <summary>
  /// User context paramenters.
  /// </summary>
  public Dictionary<string, object> Parameters { get; } = new();

  /// <summary>
  /// Is user has active command.
  /// </summary>
  public bool HasActiveCommand => MultiActionCommandContext is { IsCompleted: false };

  #endregion

  #region MyRegion

  /// <summary>
  /// Constructor.
  /// </summary>
  /// <param name="userId">Bot user ID.</param>
  public UserContext(long userId)
  {
    UserId = userId;
  }
  
  #endregion
}