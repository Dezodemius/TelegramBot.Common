using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace BotWorkerService;

public class Worker : BackgroundService
{
  private Process _botProcess;
  private readonly string runningAssemblyPath;

  public Worker(string runningAssemblyPath)
  {
    this.runningAssemblyPath = runningAssemblyPath;
    PrepareProcess();
  }

  private void PrepareProcess()
  {
    _botProcess = new Process();
    var botAssembly = Assembly.Load(this.runningAssemblyPath);
    var botExecutableFilepath = Path.ChangeExtension(botAssembly.Location, "exe");
    _botProcess.StartInfo = new ProcessStartInfo
    {
        FileName = botExecutableFilepath,
        WorkingDirectory = Path.GetDirectoryName(botAssembly.Location)
    };
  }

  protected override Task ExecuteAsync(CancellationToken stoppingToken)
  {
    stoppingToken.Register(() =>
    {
      if (!_botProcess.HasExited)
        _botProcess.Kill();
    });
    while (!stoppingToken.IsCancellationRequested)
    {
      _botProcess.Start();
      _botProcess.WaitForExit();
    }
    return Task.CompletedTask;
  }
}