using System.Runtime.InteropServices;

namespace PcRemote.Server.Infrastructure.Services.Windows;

[StructLayout(LayoutKind.Sequential)]
public struct WindowsInput
{
    /// <summary>
    // 0 = INPUT_MOUSE,
    // 1 = INPUT_KEYBOARD
    // 2 = INPUT_HARDWARE
    /// </summary>
    public int type;

    public MouseInput mi;
}