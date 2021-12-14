namespace PcRemote.Server.Infrastructure.Services.Windows;

public static class MouseEventType
{
    public const int MOUSEEVENTF_MOVED      = 0x0001 ;
    public const int MOUSEEVENTF_LEFTDOWN   = 0x0002 ;
    public const int MOUSEEVENTF_LEFTUP     = 0x0004 ;
    public const int MOUSEEVENTF_RIGHTDOWN  = 0x0008 ;
    public const int MOUSEEVENTF_RIGHTUP    = 0x0010 ;
    public const int MOUSEEVENTF_MIDDLEDOWN = 0x0020 ;
    public const int MOUSEEVENTF_MIDDLEUP   = 0x0040 ;
    public const int MOUSEEVENTF_WHEEL      = 0x0080 ;
    public const int MOUSEEVENTF_XDOWN      = 0x0100 ;
    public const int MOUSEEVENTF_XUP        = 0x0200 ;
    public const int MOUSEEVENTF_ABSOLUTE   = 0x8000 ;
}