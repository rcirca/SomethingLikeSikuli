using System;
using System.Drawing;
using SikuliLike.StateGraph;
using SikuliLike.Util.Enums;

namespace SikuliLike.Automation
{
    public static class MouseAction
    {
        public static void PerformAction(StateNode pState)
        {
            switch (pState.PerformAction)
            {
                case Actions.DoubleClickLocation:
                    PerformDoubleClick(pState.ImageLocation.CenterPoint);
                    break;
                case Actions.ClickLocation:
                    PerformSingleClick(pState.ImageLocation.CenterPoint);
                    break;
                case Actions.DragAndDrop:
                case Actions.MatchImageAndClickLocation:
                case Actions.MatchImageAndDragAndDrop:
                default:
                    break;
            }
        }

        public static void PerformDoubleClick(Point pClickLocation)
        {
            Console.WriteLine(@"Cursor: (" + pClickLocation.X + @", " + pClickLocation.Y + @")");
            MouseController.SetCursorPosition(pClickLocation.X, pClickLocation.Y);
            DoubleClick();
            //var location = new LocationPattern(pClickLocation.X, pClickLocation.Y);
            Console.WriteLine("doubleClick");
        }

        public static void PerformSingleClick(Point pClickLocation)
        {
            Console.WriteLine(@"Cursor: (" + pClickLocation.X + @", " + pClickLocation.Y + @")");
            MouseController.SetCursorPosition(pClickLocation.X, pClickLocation.Y);
            SingleClick();
            //var location = new LocationPattern(pClickLocation.X, pClickLocation.Y);
            Console.WriteLine("Click");
        }


        private static void DoubleClick()
        {
            MouseController.MouseEvent(MouseEventFlags.LeftDown);
            MouseController.MouseEvent(MouseEventFlags.LeftUp);
            MouseController.MouseEvent(MouseEventFlags.LeftDown);
            MouseController.MouseEvent(MouseEventFlags.LeftUp);
        }

        private static void SingleClick()
        {
            MouseController.MouseEvent(MouseEventFlags.LeftDown);
            MouseController.MouseEvent(MouseEventFlags.LeftUp);
        }
    }
}