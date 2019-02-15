using System;
using SikuliLike.Views.Interfaces;
using SikuliLike.Views.Intermediaries;

namespace SikuliLike.Views
{
    public partial class SikuliLikeMainView : MainWindowIntermediary, IMainView
    {
        public SikuliLikeMainView()
        {
            InitializeComponent();
        }

        public event EventHandler AddNewState;
        public event EventHandler RemoveState;
        public event EventHandler TempInitialize;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            foreach (var item in Model.StateList)
            {
                _stateListBox.Items.Add(item);
                _stateListBox.DisplayMember = "StateName";
            }
        }

        private void ClickedAddNewState(object pSender, EventArgs pEventArgs)
        {
            AddNewState(this, pEventArgs);
        }

        //use only if we have something other than X button to close application
        public event EventHandler CloseFormClicked;

        //public void exitButton_clicked(object s, EventArgs e)
        //{
        //    CloseFormClicked(this, EventArgs.Empty);
        //}
        public void Exit()
        {
            Close();
        }
    }
}