using System;
using SikuliLike.Util.Enums;
using SikuliLike.Views.Interfaces.Dialogs;
using WinFormsMvp;

namespace SikuliLike.Presenters
{
    public class AddNewNodeDialogPresenter : Presenter<IAddNewNodeDialogView>
    {
        public AddNewNodeDialogPresenter(IAddNewNodeDialogView pView) : base(pView)
        {
            pView.OkayClicked += ViewOnOkayClicked;
            pView.CancelClicked += ViewOnCancelClicked;
            pView.CaptureLocation += ViewOnCaptureLocation;
            pView.ClickLocation += ViewOnClickLocation;
            pView.Load += ViewOnLoad;
        }

        private void ViewOnClickLocation(object pSender, EventArgs pE)
        {
            throw new NotImplementedException();
        }

        private void ViewOnCaptureLocation(object pSender, EventArgs pE)
        {
            throw new NotImplementedException();
        }

        private void ViewOnLoad(object pSender, EventArgs pE)
        {

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