using IrRemoteServer.Core.Abstraction;
using IrRemoteServer.Core.Application;
using IrRemoteServer.Core.Application.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace IrRemoteServer.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddScoped<IServer, Server>();
        services.AddScoped<IMessageHandler, MessageHandler>();
        services.AddSingleton<IWScriptService, WScriptService>();
        services.AddScoped<IWindowsCommandFactory, WindowsCommandFactory>();
        services.AddScoped<TogglePauseCommand>();
        services.AddScoped<ToggleMuteCommand>();
        services.AddScoped<VolumeUpCommand>();
        services.AddScoped<VolumeDownCommand>();

        return services;
    }
}