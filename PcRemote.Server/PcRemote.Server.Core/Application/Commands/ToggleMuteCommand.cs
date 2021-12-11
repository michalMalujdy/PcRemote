using PcRemote.Server.Core.Abstraction;

namespace PcRemote.Server.Core.Application.Commands;

public class ToggleMuteCommand : ICommand
{
    private readonly IWScriptService _wScriptService;

    public ToggleMuteCommand(IWScriptService wScriptService)
        => _wScriptService = wScriptService;

    public void Execute(bool isRepeat)
    {
        if (!isRepeat)
        {
            _wScriptService.SendKey("\u00AD");
        }
    }
}