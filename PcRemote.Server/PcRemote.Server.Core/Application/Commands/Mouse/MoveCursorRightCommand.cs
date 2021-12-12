using PcRemote.Server.Core.Abstraction;

namespace PcRemote.Server.Core.Application.Commands.Mouse;

public class MoveCursorRightCommand : ICommand
{
    private readonly IOsInputService _osInputService;

    public MoveCursorRightCommand(IOsInputService osInputService)
        => _osInputService = osInputService;

    public void Execute(bool isRepeat)
    {
        _osInputService.MoveCursorRight();
    }
}