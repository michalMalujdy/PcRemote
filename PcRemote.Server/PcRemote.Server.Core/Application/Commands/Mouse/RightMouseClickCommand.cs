using PcRemote.Server.Core.Abstraction;

namespace PcRemote.Server.Core.Application.Commands.Mouse;

public class RightMouseClickCommand : ICommand
{
    private readonly IOsService _osService;

    public RightMouseClickCommand(IOsService osService)
        => _osService = osService;

    public void Execute(bool isRepeat)
    {
        if (!isRepeat)
        {
            _osService.Input.RightMouseClick();
        }
    }
}