using SikuliLike.Views.Interfaces.Dialogs;
using WinFormsMvp;

namespace SikuliLike.Presenters
{
    public class AddNewNodeDialogPresenter : Presenter<IAddNewNodeDialogView>
    {
        public AddNewNodeDialogPresenter(IAddNewNodeDialogView view) : base(view)
        {
        }
    }
}