using PcRemote.Server.Core.Abstraction;

namespace PcRemote.Server.Core.Application.Commands;

public class SequenceService : ISequenceService
{
    public int? ThirdLast { get; private set; }
    public int? SecondLast { get; private set; }
    public int? Last { get; private set; }

    public void Push(int value)
    {
        ThirdLast = SecondLast;
        SecondLast = Last;
        Last = value;
    }
}