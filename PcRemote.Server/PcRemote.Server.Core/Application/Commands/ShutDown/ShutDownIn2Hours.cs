using PcRemote.Server.Core.Abstraction;

namespace PcRemote.Server.Core.Application.Commands.ShutDown;

public class ShutDownIn2Hours : ICommand
{
    private readonly IOsInputService _osInputService;

    public ShutDownIn2Hours(IOsInputService osInputService)
        => _osInputService = osInputService;

    public void Execute(bool isRepeat)
        => _osInputService.ShutDown(TimeSpan.FromHours(2));
}