using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BotWorkerService;

public class WorkerHostRunner
{
  public void RunWorkerService(string serviceName, string runningAssemblyPath, string[] serviceArgs)
  {
    IHost host = Host.CreateDefaultBuilder(serviceArgs)
      .UseWindowsService(options =>
      {
        options.ServiceName = serviceName;
      })
      .ConfigureServices(services =>
      {
        services.AddHostedService<Worker>(_ => new Worker(runningAssemblyPath));
      })
      .Build();

    host.Run();
  }
}