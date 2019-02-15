using SikuliLike.StateGraph;
using SikuliLike.Util;
using SikuliLike.Util.Enums;

namespace SikuliLike.UI.Models.Dialogs
{
    public class AddNewNodeDialogModel
    {
        public AddNewNodeDialogModel()
        {
            Title = string.Empty;
            Action = Actions.None;
            ImageLocation = null;
        }

        public string Title { get; private set; }

        public Actions Action { get; private set; }

        public ImageLocation ImageLocation { get; private set; }

        public StateNode StateNode { get; private set; }

        public void SetTitle(string pTitle)
        {
            Title = pTitle;
        }

        public void SetAction(Actions pAction)
        {
            Action = pAction;
        }

        public void SetImageLocation(ImageLocation pImageLocation)
        {
            ImageLocation = pImageLocation;
        }

        public void SetNode()
        {
            StateNode = new StateNode(Title, ImageLocation);
        }
    }
}