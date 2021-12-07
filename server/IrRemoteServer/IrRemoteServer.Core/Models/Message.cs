namespace IrRemoteServer.Core.Models;

public class Message
{
    public int Command { get; set; }
    public bool IsRepeat { get; set; }
}