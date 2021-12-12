using PcRemote.Server.Core.Abstraction;

namespace PcRemote.Server.Core.Application.Commands.Mouse;

public class MoveCursorDownCommand : ICommand
{
    private readonly IOsInputService _osInputService;

    public MoveCursorDownCommand(IOsInputService osInputService)
        => _osInputService = osInputService;

    public void Execute(bool isRepeat)
    {
        _osInputService.MoveCursorDown();
    }
}