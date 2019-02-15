using System;

namespace SikuliLike.Views.Interfaces.Bases
{
    public interface IBaseView
    {
        event EventHandler CloseFormClicked;
        void Exit();
    }
}