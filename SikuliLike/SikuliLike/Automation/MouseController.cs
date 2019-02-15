using System.Runtime.InteropServices;
using SikuliLike.Util.Enums;

namespace SikuliLike.Automation
{
    public static class MouseController
    {
        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetCursorPos(int pX, int pY);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(out MousePoint pLpMousePoint);

        [DllImport("user32.dll")]
        private static extern void mouse_event(int pDwFlags, int pDx, int pDy, int pDwData, int pDwExtraInfo);

        public static void SetCursorPosition(int pX, int pY)
        {
            SetCursorPos(pX, pY);
        }

        public static void SetCursorPosition(MousePoint point)
        {
            SetCursorPos(point.X, point.Y);
        }

        public static MousePoint GetCursorPosition()
        {
            MousePoint currentMousePoint;
            if (!GetCursorPos(out currentMousePoint))
                currentMousePoint = new MousePoint(0, 0);

            return currentMousePoint;
        }

        public static void MouseEvent(MouseEventFlags pValue)
        {
            var position = GetCursorPosition();

            mouse_event((int) pValue, position.X, position.Y, 0, 0);
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MousePoint
        {
            public int X;
            public int Y;

            public MousePoint(int pX, int pY)
            {
                X = pX;
                Y = pY;
            }
        }
    }
}