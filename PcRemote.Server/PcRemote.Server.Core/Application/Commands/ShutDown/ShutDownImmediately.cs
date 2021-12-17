using PcRemote.Server.Core.Abstraction;

namespace PcRemote.Server.Core.Application.Commands.ShutDown;

public class ShutDownImmediately : ShutdownCommandBase
{
    protected override TimeSpan Delay => TimeSpan.Zero;

    public ShutDownImmediately(IOsService osService) : base(osService) { }
}