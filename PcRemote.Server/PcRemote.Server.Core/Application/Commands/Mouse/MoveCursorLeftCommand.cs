using PcRemote.Server.Core.Abstraction;

namespace PcRemote.Server.Core.Application.Commands.Mouse;

public class MoveCursorLeftCommand : ICommand
{
    private readonly IOsInputService _osInputService;

    public MoveCursorLeftCommand(IOsInputService osInputService)
        => _osInputService = osInputService;

    public void Execute(bool isRepeat)
    {
        _osInputService.MoveCursorLeft();
    }
}