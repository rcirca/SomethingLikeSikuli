using System.Drawing;
using SikuliLike.StateGraph;

namespace SikuliLike.ImageProcessing.Interfaces
{
    public interface IImageComparer
    {
        bool TryCompareNTimes(StateNode pStateNode, int pTries = 10);
        bool CompareStateImage(StateNode pStateNode);
        bool CompareImages(string pImage, Bitmap pTargetRegion, double pCompareLevel, float pSimilarityThreshhold);
    }
}