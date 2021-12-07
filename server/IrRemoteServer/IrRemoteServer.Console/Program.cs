using IrRemoteServer.Core.Abstraction;
using IrRemoteServer.Core.Infrastructure;
using IrRemoteServer.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddScoped<IServer, Server>();
        services.AddScoped<IMessageHandler, MessageHandler>();
        services.AddScoped<ISerialCommunicationService, SerialCommunicationService>();
    })
    .Build();

RunServerInScope(host.Services);

await host.RunAsync();

void RunServerInScope(IServiceProvider serviceProvider)
{
    var server = serviceProvider.GetRequiredService<IServer>();
    server.Start();
}

