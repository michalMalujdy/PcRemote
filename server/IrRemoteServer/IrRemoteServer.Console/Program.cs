using IrRemoteServer.Core;
using IrRemoteServer.Core.Abstraction;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddCore();
    })
    .Build();

RunServerInScope(host.Services);

await host.RunAsync();

void RunServerInScope(IServiceProvider serviceProvider)
{
    var server = serviceProvider.GetRequiredService<IServer>();
    server.Start();
}

