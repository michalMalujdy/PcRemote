using PcRemote.Server.Core.Abstraction;
using PcRemote.Server.Core.Models;

namespace PcRemote.Server.Core.Application.Commands;

public abstract class NonRepeatableKeyboardCommandBase : ICommand
{
    protected abstract Key Key { get; }

    private readonly IOsService _osService;

    protected NonRepeatableKeyboardCommandBase(IOsService osService)
        => _osService = osService;

    public void Execute(bool isRepeat)
    {
        if (!isRepeat)
        {
            _osService.Input.KeyStroke(Key);
        }
    }
}