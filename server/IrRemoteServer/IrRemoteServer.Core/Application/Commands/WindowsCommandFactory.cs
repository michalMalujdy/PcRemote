using IrRemoteServer.Core.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace IrRemoteServer.Core.Application.Commands;

public class WindowsCommandFactory : IWindowsCommandFactory
{
    private readonly IServiceProvider _serviceProvider;

    public WindowsCommandFactory(IServiceProvider serviceProvider)
        => _serviceProvider = serviceProvider;

    public ICommand CreateCommand(int remoteValue)
        => remoteValue switch
        {
            74 => _serviceProvider.GetRequiredService<TogglePauseCommand>(),
            75 => _serviceProvider.GetRequiredService<SpaceCommand>(),
            22 => _serviceProvider.GetRequiredService<ToggleMuteCommand>(),
            27 => _serviceProvider.GetRequiredService<VolumeUpCommand>(),
            26 => _serviceProvider.GetRequiredService<VolumeDownCommand>(),
            _ => _serviceProvider.GetRequiredService<EmptyCommand>()
        };
}