using System;
using System.Windows.Forms;
using SikuliLike.UI.Models.Dialogs;
using SikuliLike.Util.Enums;
using SikuliLike.Views;
using SikuliLike.Views.Interfaces.Dialogs;
using WinFormsMvp;

namespace SikuliLike.Presenters
{
    public class AddNewNodeDialogPresenter : Presenter<IAddNewNodeDialogView>
    {
        public AddNewNodeDialogPresenter(IAddNewNodeDialogView pView) : base(pView)
        {
            View.OkayClicked += ViewOnOkayClicked;
            View.CancelClicked += ViewOnCancelClicked;
            View.CaptureLocation += ViewOnCaptureLocation;
            View.ClickLocation += ViewOnClickLocation;
            View.Load += ViewOnLoad;
        }

        private void ViewOnClickLocation(object pSender, EventArgs pE)
        {
            throw new NotImplementedException();
        }

        private void ViewOnCaptureLocation(object pSender, EventArgs pE)
        {
            View.ToggleVisibility(false);
            using (var captureWindow = new CaptureImageLocationView())
            {
                captureWindow.ShowDialog();
                switch (captureWindow.DialogResult)
                {
                    case DialogResult.OK:
                        View.Model.SetImageLocation(captureWindow.ImageLocation);
                        break;
                }
            }

            View.ToggleVisibility(true);
        }

        private void ViewOnLoad(object pSender, EventArgs pE)
        {
            View.Model = new AddNewNodeDialogModel();
        }

        private void ViewOnCancelClicked(object pSender, EventArgs pE)
        {

        }

        private void ViewOnOkayClicked(object pSender, EventArgs pE)
        {
            View.Model.SetNode();
        }
    }
}