﻿using System;
using System.Windows.Forms;
using SikuliLike.StateGraph;
using SikuliLike.UI.CustomControls;
using SikuliLike.Util;
using SikuliLike.Util.Enums;
using SikuliLike.Views.Interfaces.Dialogs;
using SikuliLike.Views.Intermediaries.DialogIntermediaries;

namespace SikuliLike.Views
{
    public partial class AddNewNodeDialogView : AddNewNodeDialogIntermediary, IAddNewNodeDialogView
    {
        public AddNewNodeDialogView()
        {
            InitializeComponent();
        }
        public string Title => _titleTextBox.Text;

        public Actions Action =>
            _actionsComboBox.SelectedItem is Actions
                ? (Actions)_actionsComboBox.SelectedItem
                : Actions.None;

        public ImageLocation ImageLocation { get; }

        public StateNode NewStateNode { get; private set; }

        protected override void OnLoad(EventArgs pEventArgs)
        {
            base.OnLoad(pEventArgs);
            BuildComboBoxItems();
        }
        private void BuildComboBoxItems()
        {
            foreach (var action in (Actions[]) Enum.GetValues(typeof(Actions)))
                _actionsComboBox.Items.Add(new ComboBoxActionItem(action.ToString(), action));
            _actionsComboBox.SelectedIndex = 0;
        }

        public void OnOkayClicked(object pSender, EventArgs pEventArgs)
        {
            Model.SetTitle(_titleTextBox.Text);
            OkayClicked?.Invoke(this, pEventArgs);
            NewStateNode = Model.StateNode;
            DialogResult = DialogResult.OK;
        }

        public void OnCancelClicked(object pSender, EventArgs pEventArgs)
        {
            CancelClicked?.Invoke(this, pEventArgs);
            DialogResult = DialogResult.Cancel;
            base.Close();
        }

        public void OnCaptureLocationClicked(object pSender, EventArgs pEventArgs)
        {
            CaptureLocation?.Invoke(this, pEventArgs);
        }

        public void OnClickLocationClicked(object pSender, EventArgs pEventArgs)
        {
            ClickLocation?.Invoke(this, pEventArgs);
        }

        public void ToggleVisibility(bool pIsVisible)
        {
            Visible = pIsVisible;
            ToggledVisibility?.Invoke(this, pIsVisible);
        }

        public event EventHandler OkayClicked;
        public event EventHandler CancelClicked;
        public event EventHandler CaptureLocation;
        public event EventHandler ClickLocation;

        public event EventHandler<bool> ToggledVisibility;
    }
}
