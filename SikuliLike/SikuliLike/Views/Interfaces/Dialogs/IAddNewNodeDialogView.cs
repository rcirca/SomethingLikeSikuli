using System;
using SikuliLike.UI.Models.Dialogs;
using SikuliLike.Views.Interfaces.Bases;
using WinFormsMvp;

namespace SikuliLike.Views.Interfaces.Dialogs
{
    public interface IAddNewNodeDialogView : IOkCancelDialogView, IView<AddNewNodeDialogModel>
    {
        event EventHandler CaptureLocation;
    }
}