using Microsoft.Extensions.DependencyInjection;
using PcRemote.Server.Core.Abstraction;
using PcRemote.Server.Core.Application.Commands.Mouse;

namespace PcRemote.Server.Core.Application.Commands;

public class CommandFactory : ICommandFactory
{
    private readonly IServiceProvider _serviceProvider;

    public CommandFactory(IServiceProvider serviceProvider)
        => _serviceProvider = serviceProvider;

    public ICommand CreateCommand(int remoteValue)
        => remoteValue switch
        {
            74 => _serviceProvider.GetRequiredService<TogglePauseCommand>(),
            75 => _serviceProvider.GetRequiredService<SpaceCommand>(),
            22 => _serviceProvider.GetRequiredService<ToggleMuteCommand>(),
            27 => _serviceProvider.GetRequiredService<VolumeUpCommand>(),
            26 => _serviceProvider.GetRequiredService<VolumeDownCommand>(),
            71 => _serviceProvider.GetRequiredService<RewindCommand>(),
            70 => _serviceProvider.GetRequiredService<ForwardCommand>(),
            14 => _serviceProvider.GetRequiredService<MoveCursorRightCommand>(),
            15 => _serviceProvider.GetRequiredService<MoveCursorLeftCommand>(),
            12 => _serviceProvider.GetRequiredService<MoveCursorUpCommand>(),
            13 => _serviceProvider.GetRequiredService<MoveCursorDownCommand>(),
            16 => _serviceProvider.GetRequiredService<LeftMouseClickCommand>(),
            _ => _serviceProvider.GetRequiredService<EmptyCommand>()
        };
}