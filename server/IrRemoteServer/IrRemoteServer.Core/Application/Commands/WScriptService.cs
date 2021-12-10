using IrRemoteServer.Core.Abstraction;

namespace IrRemoteServer.Core.Application.Commands;

public class WScriptService : IWScriptService
{
    private readonly dynamic _wScript;

    public WScriptService()
        =>  _wScript = Microsoft.VisualBasic.Interaction.CreateObject("WScript.Shell");

    public void SendKey(string key)
        => _wScript.SendKeys(key);
}