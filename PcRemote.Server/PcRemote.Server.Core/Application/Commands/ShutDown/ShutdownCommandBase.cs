using PcRemote.Server.Core.Abstraction;

namespace PcRemote.Server.Core.Application.Commands.ShutDown;

public abstract class ShutdownCommandBase : ICommand
{
    protected abstract TimeSpan Delay { get; }

    private readonly IOsService _osService;

    public ShutdownCommandBase(IOsService osService)
        => _osService = osService;

    public void Execute(bool isRepeat)
        => _osService.ShutDown(Delay);
}