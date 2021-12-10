using IrRemoteServer.Core.Abstraction;

namespace IrRemoteServer.Core.Application.Commands;

public class ToggleMuteCommand : ICommand
{
    private readonly IWScriptService _wScriptService;

    public ToggleMuteCommand(IWScriptService wScriptService)
        => _wScriptService = wScriptService;

    public void Execute()
        => _wScriptService.SendKey("\u00AD");
}