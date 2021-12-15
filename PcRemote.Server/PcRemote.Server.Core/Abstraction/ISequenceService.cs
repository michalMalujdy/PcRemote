namespace PcRemote.Server.Core.Abstraction;

public interface ISequenceService
{
    public int? ThirdLast { get; }
    public int? SecondLast { get; }
    public int? Last { get; }

    public void Push(int value);
}