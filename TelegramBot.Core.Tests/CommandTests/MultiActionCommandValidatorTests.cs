using System;
using BotCommon.Commands;
using BotCommon.Commands.Exceptions;
using BotCommon.Commands.Validators;
using NUnit.Framework;

namespace BotCommon.Tests.CommandTests;

public class MultiActionCommandValidatorTests
{
  private const string TestCommandName = "/test";
  
  [Test]
  public void MultiActionCommand_BuildCommand_DoesNotThrowsException()
  {
    var command = new MultiActionCommand(TestCommandName)
      .StartWith(null)
      .Then(null)
      .End();

    Assert.DoesNotThrow(() =>
    {
      MultiActionCommandValidator.Validate(command);
    });
  }
  
    
  [Test]
  public void MultiActionCommand_BuildCommand_NotStarted_ThrowsException()
  {
    var command = new MultiActionCommand(TestCommandName)
      .Then(null)
      .End();

    Assert.Throws<MultiActionCommandNotStartedException>(() =>
    {
      MultiActionCommandValidator.Validate(command);
    });
  }
}