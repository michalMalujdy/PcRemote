using Microsoft.Extensions.DependencyInjection;
using PcRemote.Server.Core.Abstraction;
using PcRemote.Server.Core.Application.Commands.Keyboard;
using PcRemote.Server.Core.Application.Commands.Mouse;
using PcRemote.Server.Core.Application.Commands.ShutDown;

namespace PcRemote.Server.Core.Application.Commands;

public class CommandFactory : ICommandFactory
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ISequenceService _remoteSequence;

    public CommandFactory(IServiceProvider serviceProvider, ISequenceService remoteSequence)
    {
        _serviceProvider = serviceProvider;
        _remoteSequence = remoteSequence;
    }

    public ICommand CreateCommand(int remoteValue)
    {
        _remoteSequence.PushWithoutRepeat(remoteValue);

        return (_remoteSequence.Last, _remoteSequence.SecondLast, _remoteSequence.ThirdLast) switch
        {
            (74, _, _) => _serviceProvider.GetRequiredService<TogglePauseCommand>(),
            (75, _, _) => _serviceProvider.GetRequiredService<SpaceCommand>(),
            (22, _, _) => _serviceProvider.GetRequiredService<ToggleMuteCommand>(),
            (27, _, _) => _serviceProvider.GetRequiredService<VolumeUpCommand>(),
            (26, _, _) => _serviceProvider.GetRequiredService<VolumeDownCommand>(),
            (71, _, _) => _serviceProvider.GetRequiredService<RewindCommand>(),
            (70, _, _) => _serviceProvider.GetRequiredService<ForwardCommandBase>(),
            (14, _, _) => _serviceProvider.GetRequiredService<MoveCursorRightCommand>(),
            (15, _, _) => _serviceProvider.GetRequiredService<MoveCursorLeftCommand>(),
            (12, _, _) => _serviceProvider.GetRequiredService<MoveCursorUpCommand>(),
            (13, _, _) => _serviceProvider.GetRequiredService<MoveCursorDownCommand>(),
            (16, _, _) => _serviceProvider.GetRequiredService<LeftMouseClickCommand>(),
            (21, 0, 21) => _serviceProvider.GetRequiredService<ShutDownImmediately>(),
            (21, 1, 21) => _serviceProvider.GetRequiredService<ShutDownIn10Minutes>(),
            (21, 2, 21) => _serviceProvider.GetRequiredService<ShutDownIn1Hour>(),
            (21, 3, 21) => _serviceProvider.GetRequiredService<ShutDownIn2Hours>(),
            _ => _serviceProvider.GetRequiredService<EmptyCommand>()
        };
    }
}