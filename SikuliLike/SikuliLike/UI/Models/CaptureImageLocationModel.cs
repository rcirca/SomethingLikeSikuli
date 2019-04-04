using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SikuliLike.Util;

namespace SikuliLike.UI.Models
{
    public class CaptureImageLocationModel
    {

        public Point CurrentTopLeft { get; set; }

        public Point CurrentBottomRight { get; set; }
        public string ImagePathLocation { get; set; }
        public Rectangle SelectedArea { get; set; }

        public ImageLocation NewImageLocation { get; set; }

        public void SetImageLocation(string pImageLocation, Rectangle pSelectedArea)
        {
            NewImageLocation = new ImageLocation(pImageLocation, pSelectedArea);
        }
    }
}
