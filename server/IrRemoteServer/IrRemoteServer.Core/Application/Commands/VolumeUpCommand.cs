using IrRemoteServer.Core.Abstraction;

namespace IrRemoteServer.Core.Application.Commands;

public class VolumeUpCommand : ICommand
{
    private readonly IWScriptService _wScriptService;

    public VolumeUpCommand(IWScriptService wScriptService)
        => _wScriptService = wScriptService;

    public void Execute(bool isRepeat)
        => _wScriptService.SendKey("\u00AF");
}