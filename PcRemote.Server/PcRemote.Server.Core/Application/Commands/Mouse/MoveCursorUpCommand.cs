using PcRemote.Server.Core.Abstraction;

namespace PcRemote.Server.Core.Application.Commands.Mouse;

public class MoveCursorUpCommand : ICommand
{
    private readonly IOsService _osService;

    public MoveCursorUpCommand(IOsService osService)
        => _osService = osService;

    public void Execute(bool isRepeat)
    {
        _osService.Input.MoveCursor(CursorDirection.Up, isRepeat);
    }
}