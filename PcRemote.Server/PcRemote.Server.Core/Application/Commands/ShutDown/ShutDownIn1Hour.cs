using PcRemote.Server.Core.Abstraction;

namespace PcRemote.Server.Core.Application.Commands.ShutDown;

public class ShutDownIn1Hour : ShutdownCommandBase
{
    protected override TimeSpan Delay => TimeSpan.FromHours(1);

    public ShutDownIn1Hour(IOsService osService) : base(osService) { }
}