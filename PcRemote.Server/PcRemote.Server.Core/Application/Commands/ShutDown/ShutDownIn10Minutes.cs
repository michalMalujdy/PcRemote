using PcRemote.Server.Core.Abstraction;

namespace PcRemote.Server.Core.Application.Commands.ShutDown;

public class ShutDownIn10Minutes : ShutdownCommandBase
{
    protected override TimeSpan Delay => TimeSpan.FromMinutes(10);

    public ShutDownIn10Minutes(IOsService osService) : base(osService) { }
}