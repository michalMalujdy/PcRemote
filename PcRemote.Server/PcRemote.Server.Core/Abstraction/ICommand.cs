namespace PcRemote.Server.Core.Abstraction;

public interface ICommand
{
    void Execute(bool isRepeat);
}