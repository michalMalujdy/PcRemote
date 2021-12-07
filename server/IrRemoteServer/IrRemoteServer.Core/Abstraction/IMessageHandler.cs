namespace IrRemoteServer.Core.Abstraction;

public interface IMessageHandler
{
    void Handle(string message);
}