using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SikuliLike.Util.Enums
{
    public enum CaptureClickAction
    {
        NoClick = 0,
        Dragging,
        Outside,
        TopSizing,
        BottomSizing,
        LeftSizing,
        TopLeftSizing,
        BottomLeftSizing,
        RightSizing,
        TopRightSizing,
        BottomRightSizing
    }

    public enum CursorPosition
    {
        WithinSelectionArea = 0,
        OutsideSelectionArea,
        TopLine,
        BottomLine,
        LeftLine,
        RightLine,
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight
    }
}
