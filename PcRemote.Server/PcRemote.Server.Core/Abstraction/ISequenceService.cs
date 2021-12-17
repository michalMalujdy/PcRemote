namespace PcRemote.Server.Core.Abstraction;

public interface ISequenceService
{
    public int? Last { get; }
    public int? SecondLast { get; }
    public int? ThirdLast { get; }

    public void Push(int value);
    void PushWithoutRepeat(int value);
}