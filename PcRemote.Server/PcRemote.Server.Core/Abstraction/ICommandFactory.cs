namespace PcRemote.Server.Core.Abstraction;

public interface ICommandFactory
{
    ICommand CreateCommand(int remoteValue);
}