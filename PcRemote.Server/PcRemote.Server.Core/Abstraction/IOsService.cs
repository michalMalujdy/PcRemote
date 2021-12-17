namespace PcRemote.Server.Core.Abstraction;

public interface IOsService
{
    public IOsInputService Input { get; }

    void ShutDown(TimeSpan delay);
}