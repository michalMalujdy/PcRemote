using PcRemote.Server.Core.Abstraction;
using PcRemote.Server.Core.Models;

namespace PcRemote.Server.Core.Application.Commands;

public class VolumeUpCommand : RepeatableKeyboardCommandBase
{
    protected override Key Key => Key.VolumeUp;

    public VolumeUpCommand(IOsService osService) : base(osService) { }
}