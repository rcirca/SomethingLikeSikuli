using System;
using SikuliLike.UI.CustomEventArgs;
using SikuliLike.UI.Models;
using WinFormsMvp;

namespace SikuliLike.Views.Interfaces
{
    public interface IMainView : IView<SikuliLikeModel>, IHideableView
    {
        event EventHandler TempInitialize;
        event EventHandler<EventOpenDialogArgs> AddNewState;
        event EventHandler RemoveState;
    }
}