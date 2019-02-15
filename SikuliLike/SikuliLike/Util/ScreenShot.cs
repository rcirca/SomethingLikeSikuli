using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace SikuliLike.Util
{
    public class ScreenShot
    {
        public static void CaptureScreen(bool pShowCursor, Size pCursorSize, Point pCursorPosition, Point pSourcePoint,
            Point pDestinationPoint, Rectangle pSelectionRectangle, string pFilePath, string pExtension)
        {
            using (var bitmap = new Bitmap(pSelectionRectangle.Width, pSelectionRectangle.Height))
            {
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    graphics.CopyFromScreen(pSourcePoint, pDestinationPoint, pSelectionRectangle.Size);

                    if (pShowCursor)
                    {
                        var cursorBounds = new Rectangle(pCursorPosition, pCursorSize);
                        Cursors.Default.Draw(graphics, cursorBounds);
                    }
                }

                var imageFormat = ImageFormat.Jpeg;
                switch (pExtension)
                {
                    case ".bmp":
                        imageFormat = ImageFormat.Bmp;
                        break;
                    case ".jpg":
                        imageFormat = ImageFormat.Jpeg;
                        break;
                    case ".png":
                        imageFormat = ImageFormat.Png;
                        break;
                }

                bitmap.Save(pFilePath, imageFormat);
            }
        }
    }
}