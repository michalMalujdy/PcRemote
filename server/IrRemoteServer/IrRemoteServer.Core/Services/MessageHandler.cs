namespace IrRemoteServer.Core.Services;

public class MessageHandler
{
    public void Handle(string message)
    {
        var properties = message.Split(' ');

        if (properties.Contains("Repeat") || properties.Contains("Protocol=UNKNOWN"))
        {
            return;
        }

        var valueHex = properties[2].Substring(8);
        var value = Convert.ToInt32(valueHex , 16);

        Console.WriteLine(value);

        dynamic ws = Microsoft.VisualBasic.Interaction.CreateObject("WScript.Shell", "");

        switch (value)
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