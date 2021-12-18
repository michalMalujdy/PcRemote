using PcRemote.Server.Core.Abstraction;
using PcRemote.Server.Core.Models;

namespace PcRemote.Server.Core.Application.Commands.Keyboard;

public class ForwardCommandBase : NonRepeatableKeyboardCommandBase
{
    protected override Key Key => Key.ArrowRight;

    public ForwardCommandBase(IOsService osService) : base(osService) { }
}