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
            pView.Load += ViewOnLoad;
        }

        private void ViewOnCaptureLocation(object pSender, EventArgs pE)
        {
            throw new NotImplementedException();
        }

        private void ViewOnLoad(object pSender, EventArgs pE)
        {

        }
        private void BuildComboBoxItems()
        {
            foreach (var action in (Actions[])Enum.GetValues(typeof(Actions)))
            {

            }
        }

        private void ViewOnCancelClicked(object pSender, EventArgs pE)
        {
            throw new NotImplementedException();
        }

        private void ViewOnOkayClicked(object pSender, EventArgs pE)
        {
            View.Model.SetNode();
        }
    }
}