using PcRemote.Server.Core.Abstraction;

namespace PcRemote.Server.Core.Application.Commands.ShutDown;

public abstract class ShutdownCommandBase : ICommand
{
    protected abstract TimeSpan Delay { get; }

    private readonly IOsInputService _osInputService;

    public ShutdownCommandBase(IOsInputService osInputService)
        => _osInputService = osInputService;

    public void Execute(bool isRepeat)
        => _osInputService.ShutDown(Delay);
}