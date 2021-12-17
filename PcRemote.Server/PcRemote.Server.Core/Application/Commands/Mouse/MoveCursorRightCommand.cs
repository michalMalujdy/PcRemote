using PcRemote.Server.Core.Abstraction;

namespace PcRemote.Server.Core.Application.Commands.Mouse;

public class MoveCursorRightCommand : ICommand
{
    private readonly IOsService _osService;

    public MoveCursorRightCommand(IOsService osService)
        => _osService = osService;

    public void Execute(bool isRepeat)
        => _osService.Input.MoveCursor(CursorDirection.Right, isRepeat);
}