using PcRemote.Server.Core.Abstraction;

namespace PcRemote.Server.Core.Application.Commands.Mouse;

public class MoveCursorUpCommand : ICommand
{
    private readonly IOsInputService _osInputService;

    public MoveCursorUpCommand(IOsInputService osInputService)
        => _osInputService = osInputService;

    public void Execute(bool isRepeat)
    {
        _osInputService.MoveCursorUp();
    }
}