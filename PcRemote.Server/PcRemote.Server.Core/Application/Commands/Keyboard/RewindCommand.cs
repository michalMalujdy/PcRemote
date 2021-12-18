using PcRemote.Server.Core.Abstraction;
using PcRemote.Server.Core.Models;

namespace PcRemote.Server.Core.Application.Commands.Keyboard;

public class RewindCommand : NonRepeatableKeyboardCommandBase
{
    protected override Key Key => Key.ArrowLeft;

    public RewindCommand(IOsService osService) : base(osService) { }
}