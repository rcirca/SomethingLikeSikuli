using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using AForge.Imaging;
using SikuliLike.ImageProcessing.Interfaces;
using SikuliLike.StateGraph;

namespace SikuliLike.ImageProcessing
{
    public class ImageComparer : IImageComparer
    {
        public bool TryCompareNTimes(StateNode pStateNode, int pTries = 10)
        {
            for (var i = 0; i < pTries; i++)
            {
                if (CompareStateImage(pStateNode))
                    return true;
                Thread.Sleep(1000);
            }

            return false;
        }

        public bool CompareStateImage(StateNode pStateNode)
        {
            var imageArea = pStateNode.ImageLocation.ImageArea;
            var storedImg = pStateNode.ImageLocation.ImageFilePath;
            using (var bitMap = new Bitmap(imageArea.Width, imageArea.Height, PixelFormat.Format24bppRgb))
            using (var graphics = Graphics.FromImage(bitMap))
            {
                graphics.CopyFromScreen(imageArea.Left, imageArea.Top, 0, 0, bitMap.Size,
                    CopyPixelOperation.SourceCopy);
                return CompareImages(storedImg, bitMap, 0.85, 0.50f);
            }
        }

        public bool CompareImages(string pImage, Bitmap pTargetRegion, double pCompareLevel,
            float pSimilarityThreshhold)
        {
            var bitmap = ChangePixelFormat(new Bitmap(pImage), PixelFormat.Format24bppRgb);
            var otherBitmap = ChangePixelFormat(new Bitmap(pTargetRegion), PixelFormat.Format24bppRgb);

            var templateMatching = new ExhaustiveTemplateMatching(pSimilarityThreshhold);
            var results = templateMatching.ProcessImage(bitmap, otherBitmap);
            if (results.Length <= 0)
                return false;

            var match = results[0].Similarity >= pCompareLevel;
            return match;
        }

        private static Bitmap ChangePixelFormat(Bitmap pInputImage, PixelFormat pNewFormat)
        {
            return pInputImage.Clone(new Rectangle(0, 0, pInputImage.Width, pInputImage.Height), pNewFormat);
        }
    }
}