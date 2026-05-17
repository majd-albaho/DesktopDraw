using System.Runtime.InteropServices;

namespace DesktopDraw.App.Services
{
    internal class WindowsApiImplementation
    {
        public static uint MOUSELEFTDOWN = 0x02;
        public static uint MOUSELEFTUP = 0x04;


        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);

        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, UIntPtr dwExtraInfo);
    }
}
