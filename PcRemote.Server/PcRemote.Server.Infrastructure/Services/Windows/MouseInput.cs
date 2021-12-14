using System.Runtime.InteropServices;

namespace PcRemote.Server.Infrastructure.Services.Windows;

[StructLayout(LayoutKind.Sequential)]
public struct MouseInput
{
    public int dx ;
    public int dy ;
    public int mouseData ;
    public int dwFlags;
    public int time;
    public IntPtr dwExtraInfo;
}