using System.Text.Json;
using Microsoft.Extensions.Configuration;
using PcRemote.Server.Core.Abstraction;
using PcRemote.Server.Core.Models;

namespace PcRemote.Server.Core.Application;

public class MessageHandler : IMessageHandler
{
    private readonly ICommandFactory _commandFactory;
    private readonly Configuration _configuration;

    public MessageHandler(ICommandFactory commandFactory, Configuration configuration)
    {
        _commandFactory = commandFactory;
        _configuration = configuration;
    }

    public void Handle(string messageRaw)
    {
        if (_configuration.IsTestMode)
        {
            Console.WriteLine(messageRaw);
        }

        var message = JsonSerializer.Deserialize<Message>(messageRaw);

        var command = _commandFactory.CreateCommand(message!.Command);
        command.Execute(message.IsRepeat);
    }
}