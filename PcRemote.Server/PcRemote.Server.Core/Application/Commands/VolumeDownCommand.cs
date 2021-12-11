using PcRemote.Server.Core.Abstraction;

namespace PcRemote.Server.Core.Application.Commands;

public class VolumeDownCommand : ICommand
{
    private readonly IWScriptService _wScriptService;

    public VolumeDownCommand(IWScriptService wScriptService)
        => _wScriptService = wScriptService;

    public void Execute(bool isRepeat)
        => _wScriptService.SendKey("\u00AE");
}