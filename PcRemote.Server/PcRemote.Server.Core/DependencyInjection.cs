using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PcRemote.Server.Core.Abstraction;
using PcRemote.Server.Core.Application;
using PcRemote.Server.Core.Application.Commands;
using PcRemote.Server.Core.Application.Commands.Mouse;
using PcRemote.Server.Core.Application.Commands.ShutDown;

namespace PcRemote.Server.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IServer, Application.Server>();
        services.AddScoped<IMessageHandler, MessageHandler>();
        services.AddScoped<ISequenceService, SequenceService>();
        services.AddScoped<ICommandFactory, CommandFactory>();
        services.AddScoped<EmptyCommand>();
        services.AddScoped<TogglePauseCommand>();
        services.AddScoped<SpaceCommand>();
        services.AddScoped<ToggleMuteCommand>();
        services.AddScoped<VolumeUpCommand>();
        services.AddScoped<VolumeDownCommand>();
        services.AddScoped<ForwardCommandBase>();
        services.AddScoped<RewindCommand>();
        services.AddScoped<MoveCursorRightCommand>();
        services.AddScoped<MoveCursorLeftCommand>();
        services.AddScoped<MoveCursorUpCommand>();
        services.AddScoped<MoveCursorDownCommand>();
        services.AddScoped<LeftMouseClickCommand>();
        services.AddScoped<ShutDownImmediately>();
        services.AddScoped<ShutDownIn10Minutes>();
        services.AddScoped<ShutDownIn1Hour>();
        services.AddScoped<ShutDownIn2Hours>();

        var coreConfig = new Configuration();
        configuration.Bind(coreConfig);
        services.AddSingleton(coreConfig);

        return services;
    }
}