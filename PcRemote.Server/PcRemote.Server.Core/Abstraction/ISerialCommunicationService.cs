namespace PcRemote.Server.Core.Abstraction;

public interface ISerialCommunicationService
{
    void Start(Action<string> onMessageReceived);
    void Stop();
}