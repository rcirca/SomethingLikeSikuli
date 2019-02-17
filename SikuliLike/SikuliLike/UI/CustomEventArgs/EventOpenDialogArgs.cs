using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SikuliLike.UI.CustomEventArgs
{
    public class EventOpenDialogArgs : EventArgs
    {
        public EventOpenDialogArgs(IWin32Window pParentWindow)
        {
            ParentWindow = pParentWindow;
        }

        public IWin32Window ParentWindow { get; private set; }
    }
}
