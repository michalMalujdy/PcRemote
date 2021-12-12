using PcRemote.Server.Core.Abstraction;

namespace PcRemote.Server.Core.Application.Commands;

public class MoveCursorRightCommand : ICommand
{
    public void Execute(bool isRepeat)
    {
        Clicker.LeftClickAtPoint(600, 600);
    }
}