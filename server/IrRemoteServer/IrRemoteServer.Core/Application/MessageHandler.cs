using System.Text.Json;
using IrRemoteServer.Core.Abstraction;
using IrRemoteServer.Core.Models;

namespace IrRemoteServer.Core.Application;

public class MessageHandler : IMessageHandler
{
    private readonly IWindowsCommandFactory _windowsCommandFactory;

    public MessageHandler(IWindowsCommandFactory windowsCommandFactory)
        => _windowsCommandFactory = windowsCommandFactory;

    public void Handle(string messageRaw)
    {
        var message = JsonSerializer.Deserialize<Message>(messageRaw);

        var command = _windowsCommandFactory.CreateCommand(message!.Command);
        command.Execute(message.IsRepeat);
    }
}