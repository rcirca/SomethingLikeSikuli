using System.Drawing;

namespace SikuliLike.Util
{
    public class ImageLocation
    {
        public ImageLocation(string pImageFilePath, Rectangle pImageRectLoc)
        {
            ImageFilePath = pImageFilePath;
            ImageArea = pImageRectLoc;
            CenterPoint = GetCenterPoint();
        }

        public string ImageFilePath { get; private set; }
        public Rectangle ImageArea { get; private set; }
        public Point CenterPoint { get; private set; }

        public void UpdateImage(string pNewImageFilePath, Rectangle pNewImageRectlocation)
        {
            ImageFilePath = pNewImageFilePath;
            ImageArea = pNewImageRectlocation;
            CenterPoint = GetCenterPoint();
        }

        private Point GetCenterPoint()
        {
            var x = (ImageArea.X + ImageArea.Right) / 2;
            var y = (ImageArea.Y + ImageArea.Bottom) / 2;
            return new Point(x, y);
        }
    }
}