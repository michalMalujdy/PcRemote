using PcRemote.Server.Core.Abstraction;

namespace PcRemote.Server.Core.Application.Commands.Mouse;

public class LeftMouseClickCommand : ICommand
{
    private IOsService _osService;

    public LeftMouseClickCommand(IOsService osService)
        => _osService = osService;

    public void Execute(bool isRepeat)
    {
        if (!isRepeat)
        {
            _osService.Input.LeftMouseClick();
        }
    }
}