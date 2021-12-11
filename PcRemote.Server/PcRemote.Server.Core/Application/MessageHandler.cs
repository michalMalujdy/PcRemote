using System.Text.Json;
using PcRemote.Server.Core.Abstraction;
using PcRemote.Server.Core.Models;

namespace PcRemote.Server.Core.Application;

public class MessageHandler : IMessageHandler
{
    private readonly IWindowsCommandFactory _windowsCommandFactory;

    public MessageHandler(IWindowsCommandFactory windowsCommandFactory)
        => _windowsCommandFactory = windowsCommandFactory;

    public void Handle(string messageRaw)
    {
        var message = JsonSerializer.Deserialize<Message>(messageRaw);

        Console.WriteLine(message!.Command);

        var command = _windowsCommandFactory.CreateCommand(message.Command);
        command.Execute(message.IsRepeat);
    }
}