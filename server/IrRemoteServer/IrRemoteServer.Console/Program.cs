using IrRemoteServer.Core;
using IrRemoteServer.Core.Abstraction;
using IrRemoteServer.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddCore();
        services.AddInfrastructure();
    })
    .Build();

RunServerInScope(host.Services);

await host.RunAsync();

void RunServerInScope(IServiceProvider serviceProvider)
{
    var server = serviceProvider.GetRequiredService<IServer>();
    server.Start();
}

