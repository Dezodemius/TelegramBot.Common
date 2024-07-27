using System.Collections.Generic;
using System.Linq;

namespace BotCommon.Scenarios;

/// <summary>
/// Long chat command repository.
/// </summary>
public sealed class LongCommandRepository
{
  #region Fields & props

  /// <summary>
  /// Long commands.
  /// </summary>
  private readonly List<LongCommand> _longCommands = new List<LongCommand>();

  #endregion

  #region Methods

  /// <summary>
  /// Try get long command for user.
  /// </summary>
  /// <param name="userId">Telegram user ID.</param>
  /// <param name="longCommand">Founded long command.</param>
  /// <returns><c>true</c> if command exists.</returns>
  public bool TryGet(long userId, out LongCommand longCommand)
  {
    longCommand = this.Get(userId);
    return longCommand != null;
  }

  /// <summary>
  /// Get long command for user.
  /// </summary>
  /// <param name="userId">Telegram user ID.</param>
  /// <returns>Found long command.</returns>
  public LongCommand Get(long userId)
  {
    var foundedScenario = this._longCommands.SingleOrDefault(s => s.UserId == userId);
    return foundedScenario;
  }

  /// <summary>
  /// Remove command for user.
  /// </summary>
  /// <param name="userId">Telegram user ID.</param>
  public void Remove(long userId)
  {
    var foundedScenario = this.Get(userId);
    if (foundedScenario == null)
      return;

    foundedScenario.LongCommandHandler.Reset();

    this._longCommands.Remove(foundedScenario);
  }

  /// <summary>
  /// Remove command for user.
  /// </summary>
  /// <param name="command">Command for remove.</param>
  public void Remove(LongCommand command)
  {
    if (command == null)
      return;
    this.Remove(command.UserId);
  }

  /// <summary>
  /// Add or replace long command.
  /// </summary>
  /// <param name="longCommand">Command to add or replace.</param>
  public void AddOrReplace(LongCommand longCommand)
  {
    if (longCommand == null)
      return;
  
    if (this.TryGet(longCommand.UserId, out var _userCommandScenario))
      this.Remove(_userCommandScenario);

    this._longCommands.Add(longCommand);
  }

  #endregion
}