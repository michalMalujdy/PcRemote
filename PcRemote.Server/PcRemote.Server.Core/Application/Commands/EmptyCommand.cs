using PcRemote.Server.Core.Abstraction;

namespace PcRemote.Server.Core.Application.Commands;

public class EmptyCommand : ICommand
{
    public void Execute(bool isRepeat) { }
}