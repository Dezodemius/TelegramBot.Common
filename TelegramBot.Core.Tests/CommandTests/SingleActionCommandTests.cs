using System;
using BotCommon.Commands;
using BotCommon.Commands.Exceptions;
using NUnit.Framework;

namespace BotCommon.Tests.CommandTests;

public class SingleActionCommandTests
{
  [Test]
  public void SingleActionCommand_BuildCommand_TwicePerformedWith_ThrowsException()
  {
    Assert.Throws<SingleActionCommandStartedException>(() =>
    {
      _ = new SingleActionCommand("/test")
        .PerformWith(null)
        .PerformWith(null);
    });
  }

  [Test]
  public void MultiActionCommand_CreateCommand_EmptyCommandName_ThrowsException()
  {
    Assert.Throws<ArgumentNullException>(() =>
    {
      _ = new MultiActionCommand(string.Empty);
    });
  }

  [Test]
  public void MultiActionCommand_CreateCommand_NullCommandName_ThrowsException()
  {
    Assert.Throws<ArgumentNullException>(() =>
    {
      _ = new MultiActionCommand(null);
    });
  }
}