using Microsoft.Extensions.DependencyInjection;
using PcRemote.Server.Core.Abstraction;
using PcRemote.Server.Core.Application;
using PcRemote.Server.Core.Application.Commands;
using PcRemote.Server.Core.Application.Commands.Mouse;

namespace PcRemote.Server.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddScoped<IServer, Application.Server>();
        services.AddScoped<IMessageHandler, MessageHandler>();
        services.AddSingleton<IWScriptService, WScriptService>();
        services.AddScoped<ICommandFactory, CommandFactory>();
        services.AddScoped<EmptyCommand>();
        services.AddScoped<TogglePauseCommand>();
        services.AddScoped<SpaceCommand>();
        services.AddScoped<ToggleMuteCommand>();
        services.AddScoped<VolumeUpCommand>();
        services.AddScoped<VolumeDownCommand>();
        services.AddScoped<ForwardCommand>();
        services.AddScoped<RewindCommand>();
        services.AddScoped<MoveCursorRightCommand>();
        services.AddScoped<MoveCursorLeftCommand>();
        services.AddScoped<MoveCursorUpCommand>();
        services.AddScoped<MoveCursorDownCommand>();
        services.AddScoped<LeftMouseClickCommand>();

        return services;
    }
}