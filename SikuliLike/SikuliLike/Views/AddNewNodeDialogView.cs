using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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


        public void OnOkayClicked(object pSender, EventArgs pEventArgs)
        {

        }

        public void OnCancelClicked(object pSender, EventArgs pEventArgs)
        {

        }
        public event EventHandler OkayClicked;
        public event EventHandler CancelClicked;
        public event EventHandler CaptureLocation;
    }
}
