using PcRemote.Server.Core.Abstraction;
using PcRemote.Server.Core.Models;

namespace PcRemote.Server.Core.Application.Commands;

public class ToggleMuteCommand : NonRepeatableKeyboardCommandBase
{
    protected override Key Key => Key.VolumeMute;

    public ToggleMuteCommand(IOsService osService) : base(osService) { }
}