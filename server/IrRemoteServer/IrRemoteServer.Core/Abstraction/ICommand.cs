namespace IrRemoteServer.Core.Abstraction;

public interface ICommand
{
    void Execute(bool isRepeat);
}