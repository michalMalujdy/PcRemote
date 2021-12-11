namespace PcRemote.Server.Core.Abstraction;

public interface IWindowsCommandFactory
{
    ICommand CreateCommand(int remoteValue);
}