using System;

namespace SikuliLike.Views.Interfaces.Bases
{
    public interface IOkCancelDialogView
    {
        event EventHandler OkayClicked;
        event EventHandler CancelClicked;
    }
}