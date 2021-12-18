using PcRemote.Server.Core.Abstraction;
using PcRemote.Server.Core.Models;

namespace PcRemote.Server.Core.Application.Commands;

public class VolumeDownCommand : RepeatableKeyboardCommandBase
{
    protected override Key Key => Key.VolumeDown;

    public VolumeDownCommand(IOsService osService) : base(osService) { }
}