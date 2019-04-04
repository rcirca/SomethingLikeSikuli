using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace SikuliLike.Util
{
    public class ScreenShot
    {
        public static void CaptureScreen(Point pSourcePoint, Point pDestinationPoint, 
            Rectangle pSelectionRectangle, string pFilePath, string pExtension)
        {
            using (var bitmap = new Bitmap(pSelectionRectangle.Width, pSelectionRectangle.Height))
            {
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    graphics.CopyFromScreen(pSourcePoint, pDestinationPoint, pSelectionRectangle.Size);
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