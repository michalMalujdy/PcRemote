using PcRemote.Server.Core.Abstraction;

namespace PcRemote.Server.Core.Application.Commands.ShutDown;

public class ShutDownIn10Minutes : ICommand
{
    private readonly IOsInputService _osInputService;

    public ShutDownIn10Minutes(IOsInputService osInputService)
        => _osInputService = osInputService;

    public void Execute(bool isRepeat)
        => _osInputService.ShutDown(TimeSpan.FromMinutes(10));
}