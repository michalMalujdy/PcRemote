using PcRemote.Server.Core.Abstraction;
using PcRemote.Server.Core.Models;

namespace PcRemote.Server.Core.Application.Commands.Keyboard;

public class TogglePauseCommand : NonRepeatableKeyboardCommandBase
{
    protected override Key Key => Key.TogglePause;

    public TogglePauseCommand(IOsService osService) : base(osService) { }
}