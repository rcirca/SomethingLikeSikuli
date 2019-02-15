using System;
using SikuliLike.StateGraph;
using SikuliLike.UI.Models;
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
                    new StateNode("1", null),
                    new StateNode("2", null),
                    new StateNode("3", null)
                }
            };
        }

        private void OnRemoveState(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnAddNewState(object sender, EventArgs e)
        {
        }
    }
}