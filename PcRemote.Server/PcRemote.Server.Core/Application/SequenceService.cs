using PcRemote.Server.Core.Abstraction;

namespace PcRemote.Server.Core.Application;

public class SequenceService : ISequenceService
{
    public int? Last { get; private set; }
    public int? SecondLast { get; private set; }
    public int? ThirdLast { get; private set; }

    public void Push(int value)
    {
        ThirdLast = SecondLast;
        SecondLast = Last;
        Last = value;
    }

    public void PushWithoutRepeat(int value)
    {
        if (value != Last)
        {
            Push(value);
        }
    }
}