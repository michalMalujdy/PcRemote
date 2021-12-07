using IrRemoteServer.Core.Abstraction;
using IrRemoteServer.Core.Infrastructure;
using IrRemoteServer.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace IrRemoteServer.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddScoped<IServer, Server>();
        services.AddScoped<IMessageHandler, MessageHandler>();
        services.AddScoped<ISerialCommunicationService, SerialCommunicationService>();

        return services;
    }
}