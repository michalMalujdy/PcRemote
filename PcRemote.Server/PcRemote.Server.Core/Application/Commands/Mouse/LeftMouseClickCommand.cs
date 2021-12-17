using PcRemote.Server.Core.Abstraction;

namespace PcRemote.Server.Core.Application.Commands.Mouse;

public class LeftMouseClickCommand : ICommand
{
    private IOsInputService _osInputService;

    public LeftMouseClickCommand(IOsInputService osInputService)
        => _osInputService = osInputService;

    public void Execute(bool isRepeat)
    {
        if (!isRepeat)
        {
            _osInputService.LeftMouseClick();
        }
    }
}