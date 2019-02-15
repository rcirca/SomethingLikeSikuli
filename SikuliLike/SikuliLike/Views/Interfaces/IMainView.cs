using System;
using SikuliLike.UI.Models;
using WinFormsMvp;

namespace SikuliLike.Views.Interfaces
{
    public interface IMainView : IView<SikuliLikeModel>
    {
        event EventHandler TempInitialize;
        event EventHandler AddNewState;
        event EventHandler RemoveState;
    }
}