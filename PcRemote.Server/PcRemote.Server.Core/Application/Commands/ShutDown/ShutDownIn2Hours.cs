using PcRemote.Server.Core.Abstraction;

namespace PcRemote.Server.Core.Application.Commands.ShutDown;

public class ShutDownIn2Hours : ShutdownCommandBase
{
    protected override TimeSpan Delay => TimeSpan.FromHours(2);

    public ShutDownIn2Hours(IOsService osService) : base(osService) { }
}