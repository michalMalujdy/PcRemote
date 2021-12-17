using PcRemote.Server.Core.Abstraction;

namespace PcRemote.Server.Core.Application.Commands.ShutDown;

public class ShutDownImmediately : ICommand
{
    private readonly IOsInputService _osInputService;

    public ShutDownImmediately(IOsInputService osInputService)
        => _osInputService = osInputService;

    public void Execute(bool isRepeat)
        => _osInputService.ShutDown(TimeSpan.Zero);
}