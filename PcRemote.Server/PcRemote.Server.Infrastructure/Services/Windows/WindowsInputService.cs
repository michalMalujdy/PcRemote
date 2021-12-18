using PcRemote.Server.Core.Abstraction;
using PcRemote.Server.Core.Models;
using PcRemote.Server.Infrastructure.Abstraction.Windows;
using WindowsInput;

namespace PcRemote.Server.Infrastructure.Services.Windows;

public class WindowsInputService : IOsInputService
{
    private const int AccelerationIncrement = 5;
    private const int AccelerationRepeatsThreshold = 3;

    private int _speed = 1;
    private int _repeatsCount;

    private readonly IInputSimulator _inputSimulator;
    private readonly IWindowsKeyProvider _keyProvider;

    public WindowsInputService(IInputSimulator inputSimulator, IWindowsKeyProvider keyProvider)
    {
        _inputSimulator = inputSimulator;
        _keyProvider = keyProvider;
    }

    public void LeftMouseClick()
        => _inputSimulator.Mouse.LeftButtonClick();

    public void RightMouseClick()
        => _inputSimulator.Mouse.RightButtonClick();

    public void MoveCursor(CursorDirection direction, bool isRepeat)
    {
        ComputeSpeed(isRepeat);

        var dx = direction switch
        {
            CursorDirection.Right => _speed,
            CursorDirection.Left => -_speed,
            _ => 0
        };

        var dy = direction switch
        {
            CursorDirection.Down => _speed,
            CursorDirection.Up => -_speed,
            _ => 0
        };

        _inputSimulator.Mouse.MoveMouseBy(dx, dy);
    }

    public void KeyStroke(Key key)
    {
        var windowsKey = _keyProvider.GetWindowsKey(key);
        _inputSimulator.Keyboard.KeyPress(windowsKey);
    }

    private void ComputeSpeed(bool isRepeat)
    {
        if (isRepeat)
        {
            _repeatsCount++;

            if (AccelerationRepeatsThreshold == _repeatsCount)
            {
                _speed += AccelerationIncrement;
                _repeatsCount = 0;
            }
        }
        else
        {
            _repeatsCount = 0;
            _speed = 1;
        }
    }
}