using System.Runtime.InteropServices;
using PcRemote.Server.Core.Abstraction;

namespace PcRemote.Server.Infrastructure.Services;

/// <summary>
/// Input are based on the Wind32 API - https://docs.microsoft.com/en-us/windows/win32/api/winuser/
/// Keystrokes and mouse inputs are based on the SendInput() - https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-sendinput
/// </summary>

public class WindowsInputService : IOsInputService
{
    //https://msdn.microsoft.com/en-us/library/windows/desktop/ms646270(v=vs.85).aspx
    [StructLayout(LayoutKind.Sequential)]
    struct INPUT
    {
        public int        type; // 0 = INPUT_MOUSE,
                                // 1 = INPUT_KEYBOARD
                                // 2 = INPUT_HARDWARE
        public MOUSEINPUT mi;
    }

    //https://msdn.microsoft.com/en-us/library/windows/desktop/ms646273(v=vs.85).aspx
    [StructLayout(LayoutKind.Sequential)]
    struct MOUSEINPUT
    {
        public int    dx ;
        public int    dy ;
        public int    mouseData ;
        public int    dwFlags;
        public int    time;
        public IntPtr dwExtraInfo;
    }

    //This covers most use cases although complex mice may have additional buttons
    //There are additional constants you can use for those cases, see the msdn page
    const int MOUSEEVENTF_MOVED      = 0x0001 ;
    const int MOUSEEVENTF_LEFTDOWN   = 0x0002 ;
    const int MOUSEEVENTF_LEFTUP     = 0x0004 ;
    const int MOUSEEVENTF_RIGHTDOWN  = 0x0008 ;
    const int MOUSEEVENTF_RIGHTUP    = 0x0010 ;
    const int MOUSEEVENTF_MIDDLEDOWN = 0x0020 ;
    const int MOUSEEVENTF_MIDDLEUP   = 0x0040 ;
    const int MOUSEEVENTF_WHEEL      = 0x0080 ;
    const int MOUSEEVENTF_XDOWN      = 0x0100 ;
    const int MOUSEEVENTF_XUP        = 0x0200 ;
    const int MOUSEEVENTF_ABSOLUTE   = 0x8000 ;

    const int screen_length = 0x10000 ;

    private const int ScreenWidth = 3440;
    private const int ScreenHeight = 1440;
    private int _speed = 1;
    private int _acceleration = 2;
    private int _accelerationRepeatsThreshold = 3;
    private int _repeatsCount;

    [DllImport("user32.dll")]
    static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

    public void LeftClickAtPoint(int x, int y)
    {
        INPUT[] input = new INPUT[3];
        input[0].mi.dx = x * (65535 / ScreenWidth);
        input[0].mi.dy = y * (65535 / ScreenHeight);
        input[0].mi.dwFlags = MOUSEEVENTF_MOVED | MOUSEEVENTF_ABSOLUTE;
        //Left mouse button down
        input[1].mi.dwFlags = MOUSEEVENTF_LEFTDOWN;
        //Left mouse button up
        input[2].mi.dwFlags = MOUSEEVENTF_LEFTUP;
        SendInput(3, input, Marshal.SizeOf(input[0]));
    }

    public void LeftMouseClick()
    {
        var input = new INPUT[2];

        input[0].mi.dwFlags = MOUSEEVENTF_LEFTDOWN;
        input[1].mi.dwFlags = MOUSEEVENTF_LEFTUP;

        SendInput((uint)input.Length, input, Marshal.SizeOf(input[0]));
    }

    public void MoveCursor(CursorDirection direction, bool isRepeat)
    {
        ComputeSpeed(isRepeat);

        var input = new INPUT[1];
        var incrementDirection = GetIncrementDirection(direction);
        SetMovement(input, direction, incrementDirection);

        SendInput((uint)input.Length, input, Marshal.SizeOf(input[0]));
    }

    private void SetMovement(INPUT[] input, CursorDirection direction, int incrementDirection)
    {
        input[0].mi.dwFlags = MOUSEEVENTF_MOVED;

        var newPosition = incrementDirection * _speed * (65535 / ScreenWidth);
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

            if (_accelerationRepeatsThreshold == _repeatsCount)
            {
                _speed += _acceleration;
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