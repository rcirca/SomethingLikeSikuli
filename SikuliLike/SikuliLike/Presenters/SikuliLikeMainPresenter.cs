using System;
using SikuliLike.StateGraph;
using SikuliLike.UI.CustomEventArgs;
using SikuliLike.UI.Models;
using SikuliLike.Views;
using SikuliLike.Views.Interfaces;
using WinFormsMvp;

namespace SikuliLike.Presenters
{
    public class SikuliLikeMainPresenter : Presenter<IMainView>
    {
        public SikuliLikeMainPresenter(IMainView view)
            : base(view)
        {
            View.AddNewState += OnAddNewState;
            View.RemoveState += OnRemoveState;
            View.Load += ViewOnLoad;
        }

        private void ViewOnLoad(object sender, EventArgs e)
        {
            View.Model = new SikuliLikeModel
            {
                StateList =
                {
                    new StateNode("Start", null),
                    new StateNode("Open", null),
                    new StateNode("Close", null)
                }
            };
        }

        private void OnRemoveState(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnAddNewState(object sender, EventOpenDialogArgs e)
        {
            using (var dialog = new AddNewNodeDialogView())
            {
                dialog.ShowDialog(e.ParentWindow);
                switch (dialog.DialogResult)
                {

                }
            }
        }
    }
}