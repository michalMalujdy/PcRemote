using PcRemote.Server.Core.Abstraction;
using PcRemote.Server.Core.Models;

namespace PcRemote.Server.Core.Application.Commands;

public abstract class RepeatableKeyboardCommandBase : ICommand
{
    protected abstract Key Key { get; }

    private readonly IOsService _osService;

    protected RepeatableKeyboardCommandBase(IOsService osService)
        => _osService = osService;

    public void Execute(bool isRepeat)
        => _osService.Input.KeyStroke(Key);
}