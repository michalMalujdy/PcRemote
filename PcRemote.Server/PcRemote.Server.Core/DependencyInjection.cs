using Microsoft.Extensions.DependencyInjection;
using PcRemote.Server.Core.Abstraction;
using PcRemote.Server.Core.Application;
using PcRemote.Server.Core.Application.Commands;

namespace PcRemote.Server.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddScoped<IServer, Application.Server>();
        services.AddScoped<IMessageHandler, MessageHandler>();
        services.AddSingleton<IWScriptService, WScriptService>();
        services.AddScoped<IWindowsCommandFactory, WindowsCommandFactory>();
        services.AddScoped<EmptyCommand>();
        services.AddScoped<TogglePauseCommand>();
        services.AddScoped<SpaceCommand>();
        services.AddScoped<ToggleMuteCommand>();
        services.AddScoped<VolumeUpCommand>();
        services.AddScoped<VolumeDownCommand>();

        return services;
    }
}