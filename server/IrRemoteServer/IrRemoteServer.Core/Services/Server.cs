using IrRemoteServer.Core.Abstraction;

namespace IrRemoteServer.Core.Services;

public class Server : IServer
{
    private readonly ISerialCommunicationService _serialCommunicationService;
    private readonly IMessageHandler _messageHandler;

    public Server(ISerialCommunicationService serialCommunicationService, IMessageHandler messageHandler)
    {
        _serialCommunicationService = serialCommunicationService;
        _messageHandler = messageHandler;
    }

    public void Start()
    {
        _serialCommunicationService.Start(_messageHandler.Handle);
    }

    public void Stop()
    {
        _serialCommunicationService.Stop();
    }
}