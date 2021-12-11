using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PcRemote.Server.Core;
using PcRemote.Server.Core.Abstraction;
using PcRemote.Server.Infrastructure;

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

