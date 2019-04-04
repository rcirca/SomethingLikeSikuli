using System;
using System.Windows.Forms;
using SikuliLike.StateGraph;
using SikuliLike.UI.CustomEventArgs;
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

        public event EventHandler<EventOpenDialogArgs> AddNewState;
        public event EventHandler RemoveState;
        public event EventHandler TempInitialize;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            RebuildList();
        }

        private void RebuildList()
        {
            foreach (var item in Model.StateList)
            {
                _stateListBox.Items.Add(item);
                _stateListBox.DisplayMember = "StateName";
            }
        }

        private void ClickedAddNewState(object pSender, EventArgs pEventArgs)
        {
            AddNewState?.Invoke(this, new EventOpenDialogArgs(this));
            RebuildList();
        }

        public void ToggleVisibility(bool pIsVisible)
        {
            Visible = pIsVisible;
        }

        public void StateSelectedChanged(object pSender, EventArgs pEventArgs)
        {

            var state = _stateListBox?.SelectedItem as StateNode;
            if (state == null)
                return;

            _previewPictureBox.ImageLocation = state.ImageLocation.ImageFilePath;
            _previewPictureBox.SizeMode = PictureBoxSizeMode.CenterImage;

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