using Microsoft.Extensions.DependencyInjection;
using PcRemote.Server.Core.Abstraction;
using PcRemote.Server.Infrastructure.Abstraction.Windows;
using PcRemote.Server.Infrastructure.Services;
using PcRemote.Server.Infrastructure.Services.Windows;
using WindowsInput;

namespace PcRemote.Server.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ISerialCommunicationService, SerialCommunicationService>();
        services.AddScoped<IOsService, WindowsService>();
        services.AddScoped<IOsInputService, WindowsInputService>();
        services.AddScoped<IInputSimulator, InputSimulator>();
        services.AddScoped<IWindowsKeyProvider, WindowsKeyProvider>();

        return services;
    }
}