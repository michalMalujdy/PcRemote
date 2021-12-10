using IrRemoteServer.Core.Abstraction;

namespace IrRemoteServer.Core.Application.Commands;

public class TogglePauseCommand : ICommand
{
    private readonly IWScriptService _wScriptService;

    public TogglePauseCommand(IWScriptService wScriptService)
        => _wScriptService = wScriptService;

    public void Execute()
        => _wScriptService.SendKey("\u00B3");
}