using PcRemote.Server.Core.Abstraction;

namespace PcRemote.Server.Core.Application.Commands.Mouse;

public class MoveCursorDownCommand : ICommand
{
    private readonly IOsService _osService;

    public MoveCursorDownCommand(IOsService osService)
        => _osService = osService;

    public void Execute(bool isRepeat)
        => _osService.Input.MoveCursor(CursorDirection.Down, isRepeat);
}