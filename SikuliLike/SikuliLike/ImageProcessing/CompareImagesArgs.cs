using System.Drawing;

namespace SikuliLike.ImageProcessing
{
    public class CompareImagesArgs
    {
        public CompareImagesArgs(Bitmap pFirstImage, Bitmap pSecondImage)
        {
            FirstImage = pFirstImage;
            SecondImage = pSecondImage;
        }

        public Bitmap FirstImage { get; }
        public Bitmap SecondImage { get; }
    }
}