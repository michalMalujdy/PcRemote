using PcRemote.Server.Core.Abstraction;

namespace PcRemote.Server.Core.Application.Commands;

public class WScriptService : IWScriptService
{
    private readonly dynamic _wScript;

    public WScriptService()
        =>  _wScript = Microsoft.VisualBasic.Interaction.CreateObject("WScript.Shell");

    public void SendKey(string key)
        => _wScript.SendKeys(key);
}