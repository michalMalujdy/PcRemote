using IrRemoteServer.Core.Application.Commands;

namespace IrRemoteServer.Core.Abstraction;

public interface IWindowsCommandFactory
{
    ICommand CreateCommand(int remoteValue);
}