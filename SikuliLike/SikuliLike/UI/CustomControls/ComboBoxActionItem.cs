using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SikuliLike.Util.Enums;

namespace SikuliLike.UI.CustomControls
{
    public class ComboBoxActionItem : ListViewItem
    {
        public string Text { get; set; }
        public Actions Value { get; set; }

        public ComboBoxActionItem(string pText, Actions pAction)
        {
            Text = pText;
            Value = pAction;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
