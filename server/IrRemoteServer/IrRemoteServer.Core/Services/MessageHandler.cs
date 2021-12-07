using System.Text.Json;
using IrRemoteServer.Core.Models;

namespace IrRemoteServer.Core.Services;

public class MessageHandler
{
    public void Handle(string message)
    {
        var messageDeserialized = JsonSerializer.Deserialize<Message>(message);

        Console.WriteLine(messageDeserialized!.Command);

        dynamic ws = Microsoft.VisualBasic.Interaction.CreateObject("WScript.Shell", "");

        switch (messageDeserialized.Command)
        {
            case 22:
                ws.SendKeys("\u00AD"); // mute or unmute
                break;
            case 74:
                ws.SendKeys("\u00B3"); // start stop
                break;
            case 27:
                ws.SendKeys("\u00AF"); // vol up
                break;
            case 26:
                ws.SendKeys("\u00AE"); // vol down
                break;
            case 21:
                ws.SendKeys("\u00B7"); // turn off
                break;
        }
    }
}