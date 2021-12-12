using System.Text.Json;
using PcRemote.Server.Core.Abstraction;
using PcRemote.Server.Core.Models;

namespace PcRemote.Server.Core.Application;

public class MessageHandler : IMessageHandler
{
    private readonly ICommandFactory _commandFactory;

    public MessageHandler(ICommandFactory commandFactory)
        => _commandFactory = commandFactory;

    public void Handle(string messageRaw)
    {
        var message = JsonSerializer.Deserialize<Message>(messageRaw);

        Console.WriteLine(message!.Command);

        var command = _commandFactory.CreateCommand(message.Command);
        command.Execute(message.IsRepeat);
    }
}