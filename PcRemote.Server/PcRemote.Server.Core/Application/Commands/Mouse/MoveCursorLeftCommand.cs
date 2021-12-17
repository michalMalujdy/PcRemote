using PcRemote.Server.Core.Abstraction;

namespace PcRemote.Server.Core.Application.Commands.Mouse;

public class MoveCursorLeftCommand : ICommand
{
    private readonly IOsService _osService;

    public MoveCursorLeftCommand(IOsService osService)
        => _osService = osService;

    public void Execute(bool isRepeat)
        => _osService.Input.MoveCursor(CursorDirection.Left, isRepeat);
}