namespace PcRemote.Server.Core.Abstraction;

public interface IOsInputService
{
    void LeftMouseClick();
    void RightMouseClick();
    void MoveCursor(CursorDirection direction, bool isRepeat);
    void ShutDown(TimeSpan delay);
}