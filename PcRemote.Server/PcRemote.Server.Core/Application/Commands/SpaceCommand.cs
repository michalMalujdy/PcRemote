using PcRemote.Server.Core.Abstraction;
using PcRemote.Server.Core.Models;

namespace PcRemote.Server.Core.Application.Commands;

public class SpaceCommand : NonRepeatableKeyboardCommandBase
{
    protected override Key Key => Key.Space;

    public SpaceCommand(IOsService osService) : base(osService) { }
}