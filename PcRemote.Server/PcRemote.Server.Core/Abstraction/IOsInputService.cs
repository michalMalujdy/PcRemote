namespace PcRemote.Server.Core.Abstraction;

public interface IOsInputService
{
    void LeftClickAtPoint(int x, int y);
    void LeftMouseClick();
    void RightMouseClick();
    void MoveCursorRight();
    void MoveCursorLeft();
    void MoveCursorUp();
    void MoveCursorDown();
}