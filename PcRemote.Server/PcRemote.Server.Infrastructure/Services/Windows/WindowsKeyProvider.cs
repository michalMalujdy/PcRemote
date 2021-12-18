using PcRemote.Server.Core.Models;
using PcRemote.Server.Infrastructure.Abstraction.Windows;
using WindowsInput.Native;

namespace PcRemote.Server.Infrastructure.Services.Windows;

public class WindowsKeyProvider : IWindowsKeyProvider
{
    public VirtualKeyCode GetWindowsKey(Key key)
    {
        return key switch
        {
            Key.VolumeUp => VirtualKeyCode.VOLUME_UP,
            Key.VolumeDown => VirtualKeyCode.VOLUME_DOWN,
            Key.VolumeMute => VirtualKeyCode.VOLUME_MUTE,
            Key.Space => VirtualKeyCode.SPACE,
            Key.ArrowRight => VirtualKeyCode.RIGHT,
            Key.ArrowLeft => VirtualKeyCode.LEFT,
            Key.TogglePause => VirtualKeyCode.MEDIA_PLAY_PAUSE,
            _ => throw new ArgumentOutOfRangeException(nameof(key), key, null)
        };
    }
}