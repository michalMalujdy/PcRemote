using PcRemote.Server.Core.Abstraction;

namespace PcRemote.Server.Core.Application.Commands;

public class TogglePauseCommand : ICommand
{
    private readonly IWScriptService _wScriptService;

    public TogglePauseCommand(IWScriptService wScriptService)
        => _wScriptService = wScriptService;

    public void Execute(bool isRepeat)
    {
        if (!isRepeat)
        {
            _wScriptService.SendKey("\u00B3");
        }
    }
}