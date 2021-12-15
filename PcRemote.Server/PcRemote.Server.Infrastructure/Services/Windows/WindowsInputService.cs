using System.Runtime.InteropServices;
using PcRemote.Server.Core.Abstraction;

namespace PcRemote.Server.Infrastructure.Services.Windows;

/// <summary>
/// Input are based on the Wind32 API - https://docs.microsoft.com/en-us/windows/win32/api/winuser/
/// Keystrokes and mouse inputs are based on the SendInput() - https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-sendinput
/// </summary>
public class WindowsInputService : IOsInputService
{
    [DllImport("user32.dll")]
    static extern uint SendInput(uint nInputs, WindowsInput[] pInputs, int cbSize);

    private const int PositionIncrement = 5;
    private const int AccelerationIncrement = 4;
    private const int AccelerationRepeatsThreshold = 3;
    private int _speed = 1;
    private int _repeatsCount;

    public void LeftMouseClick()
    {
        var input = new WindowsInput[2];

        input[0].mi.dwFlags = MouseEventType.MOUSEEVENTF_LEFTDOWN;
        input[1].mi.dwFlags = MouseEventType.MOUSEEVENTF_LEFTUP;

        SendInput((uint)input.Length, input, Marshal.SizeOf(input[0]));
    }

    public void MoveCursor(CursorDirection direction, bool isRepeat)
    {
        ComputeSpeed(isRepeat);

        var input = new WindowsInput[1];
        SetMovement(input, direction);

        SendInput((uint)input.Length, input, Marshal.SizeOf(input[0]));
    }

    private void SetMovement(WindowsInput[] input, CursorDirection direction)
    {
        input[0].mi.dwFlags = MouseEventType.MOUSEEVENTF_MOVED;
        var incrementDirection = GetIncrementDirection(direction);

        var newPosition = incrementDirection * _speed * PositionIncrement;
        if (direction is CursorDirection.Down or CursorDirection.Up)
        {
            input[0].mi.dy = newPosition;
        }
        if (direction is CursorDirection.Left or CursorDirection.Right)
        {
            input[0].mi.dx = newPosition;
        }
    }

    private static int GetIncrementDirection(CursorDirection direction)
        => direction switch
        {
            CursorDirection.Right => 1,
            CursorDirection.Down => 1,
            CursorDirection.Left => -1,
            CursorDirection.Up => -1,
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };

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

    public void RightMouseClick()
    {
    }
}