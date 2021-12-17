using PcRemote.Server.Core.Abstraction;

namespace PcRemote.Server.Core.Application.Commands.ShutDown;

public class ShutDownIn1Hour : ICommand
{
    private readonly IOsInputService _osInputService;

    public ShutDownIn1Hour(IOsInputService osInputService)
        => _osInputService = osInputService;

    public void Execute(bool isRepeat)
        => _osInputService.ShutDown(TimeSpan.FromHours(1));
}