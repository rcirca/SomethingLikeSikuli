using System;
using SikuliLike.StateGraph;
using SikuliLike.UI.Models.Dialogs;
using SikuliLike.Util;
using SikuliLike.Util.Enums;
using SikuliLike.Views.Interfaces.Bases;
using WinFormsMvp;

namespace SikuliLike.Views.Interfaces.Dialogs
{
    public interface IAddNewNodeDialogView : IOkCancelDialogView, IView<AddNewNodeDialogModel>, IHideableView
    {
        event EventHandler CaptureLocation;
        event EventHandler ClickLocation;

        string Title { get; }
        Actions Action { get; }
        ImageLocation ImageLocation { get; }
        StateNode NewStateNode { get; }
    }
}