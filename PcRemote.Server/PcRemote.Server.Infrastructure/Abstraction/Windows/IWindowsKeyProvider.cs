using PcRemote.Server.Core.Models;
using WindowsInput.Native;

namespace PcRemote.Server.Infrastructure.Abstraction.Windows;

public interface IWindowsKeyProvider
{
    VirtualKeyCode GetWindowsKey(Key key);
}