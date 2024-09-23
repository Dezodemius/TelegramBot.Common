using BotCommon.Commands;
using BotCommon.UserContexts;
using Moq;
using NUnit.Framework;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BotCommon.Tests.CommandTests;

[TestFixture]
public class MultiActionCommandTests
{
  private Mock<ITelegramBotClient> _clientMock;

  [OneTimeSetUp]
  public void OneTimeSetUp()
  {
    this._clientMock = new Mock<ITelegramBotClient>();
  }
  
  [Test]
  public void MultiActionCommand_ExecuteCommand_AllActionsCalledAndCommandCompleted()
  {
    var args = new CommandArgs((long)11, this._clientMock.Object, new Update());
    var userContext = new UserContext((long)11);
    bool startActionCalled = false;
    bool thenAction1Called = false;
    bool thenAction2Called = false;
    var command = new MultiActionCommand("/test")
      .StartWith((_, _) => startActionCalled = true)
      .Then((_, _) => thenAction1Called = true)
      .CompleteAfter((_, _) => thenAction2Called = true);
    
    command.ExecuteCommand(userContext, args);
    command.ExecuteCommand(userContext, args);
    command.ExecuteCommand(userContext, args);
    
    Assert.Multiple(() =>
    {
      Assert.That(startActionCalled && thenAction1Called && thenAction2Called, Is.True);
      Assert.That(command.IsCompleted, Is.True);      
    });
  }
  
  [Test]
  public void MultiActionCommand_ExecuteCommand_AllActionsCalledAndCommandNotCompleted()
  {
    var args = new CommandArgs((long)11, this._clientMock.Object, new Update());
    var userContext = new UserContext((long)11);
    bool startActionCalled = false;
    bool thenAction1Called = false;
    var command = new MultiActionCommand("/test")
      .StartWith((_, _) => startActionCalled = true)
      .Then((_, _) => thenAction1Called = true)
      .CompleteAfter(null);
    
    command.ExecuteCommand(userContext, args);
    command.ExecuteCommand(userContext, args);
    
    Assert.Multiple(() =>
    {
      Assert.That(startActionCalled && thenAction1Called, Is.True);
      Assert.That(command.IsCompleted, Is.False);      
    });
  }
  
  
}