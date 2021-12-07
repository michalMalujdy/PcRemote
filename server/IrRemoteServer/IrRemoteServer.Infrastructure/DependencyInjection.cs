using IrRemoteServer.Core.Abstraction;
using IrRemoteServer.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace IrRemoteServer.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ISerialCommunicationService, SerialCommunicationService>();

        return services;
    }
}