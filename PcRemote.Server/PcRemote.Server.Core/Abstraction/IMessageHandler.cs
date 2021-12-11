namespace PcRemote.Server.Core.Abstraction;

public interface IMessageHandler
{
    void Handle(string messageRaw);
}