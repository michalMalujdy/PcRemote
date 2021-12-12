using PcRemote.Server.Core.Abstraction;

namespace PcRemote.Server.Core.Application.Commands;

public class RewindCommand : ICommand
{
    private readonly IWScriptService _wScriptService;

    public RewindCommand(IWScriptService wScriptService)
        => _wScriptService = wScriptService;

    public void Execute(bool isRepeat)
    {
        if (!isRepeat)
        {
            _wScriptService.SendKey("{LEFT}");
        }
    }
}