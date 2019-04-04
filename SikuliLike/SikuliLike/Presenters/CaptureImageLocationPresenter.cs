using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SikuliLike.UI.Models;
using SikuliLike.Util;
using SikuliLike.Views.Interfaces;
using WinFormsMvp;

namespace SikuliLike.Presenters
{
    public class CaptureImageLocationPresenter : Presenter<ICaptureView>
    {
        public CaptureImageLocationPresenter(ICaptureView pView) : base(pView)
        {
            View.SaveSelection += ViewOnSaveSelection;
            View.Load += ViewOnLoad;
        }

        private void ViewOnSaveSelection(object pSender, EventArgs pEventArgs)
        {
            SaveImage();
        }

        private void ViewOnLoad(object pSender, EventArgs pEventArgs)
        {
            View.Model = new CaptureImageLocationModel();
        }

        public void SaveImage()
        {

            var screenPath = PresentSaveFileDialog();

            if (screenPath != "")
            {
                //Allow 250 milliseconds for the screen to repaint itself (we don't want to include this form in the capture)
                Task.Delay(500);

                var startPoint = new Point(View.Model.CurrentTopLeft.X, View.Model.CurrentTopLeft.Y);
                var bounds = new Rectangle(View.Model.CurrentTopLeft.X, View.Model.CurrentTopLeft.Y,
                    View.Model.CurrentBottomRight.X - View.Model.CurrentTopLeft.X, View.Model.CurrentBottomRight.Y - View.Model.CurrentTopLeft.Y);
                var fi = "";

                if (screenPath != "")
                    fi = new FileInfo(screenPath).Extension;

                ScreenShot.CaptureScreen(startPoint, Point.Empty, bounds, screenPath, fi);
                View.Model.SelectedArea = bounds;

                MessageBox.Show("Area saved to file", "SikuliLike", MessageBoxButtons.OK);
                View.Model.ImagePathLocation = screenPath;
                View.Model.SetImageLocation(screenPath, bounds);
            }
            else
            {
                MessageBox.Show("File save cancelled", "Abort", MessageBoxButtons.OK);
            }
        }

        private string PresentSaveFileDialog()
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.DefaultExt = "png";
                saveFileDialog.Filter = "jpg files (*.jpg)|*.jpg";
                saveFileDialog.Title = "Save screenshot to...";
                saveFileDialog.ShowDialog();
                return saveFileDialog.FileName;
            }
        }
    }
}
