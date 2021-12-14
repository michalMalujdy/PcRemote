using Microsoft.Extensions.DependencyInjection;
using PcRemote.Server.Core.Abstraction;
using PcRemote.Server.Infrastructure.Services;
using PcRemote.Server.Infrastructure.Services.Windows;

namespace PcRemote.Server.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ISerialCommunicationService, SerialCommunicationService>();
        services.AddScoped<IOsInputService, WindowsInputService>();

        return services;
    }
}