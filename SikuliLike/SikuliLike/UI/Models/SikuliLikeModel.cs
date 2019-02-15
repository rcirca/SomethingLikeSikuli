using System.Collections.Generic;
using SikuliLike.StateGraph;

namespace SikuliLike.UI.Models
{
    public class SikuliLikeModel
    {
        public SikuliLikeModel()
        {
            StateList = new List<StateNode>();
        }

        public List<StateNode> StateList { get; }

        public void AddNewState(StateNode pNode)
        {
            StateList.Add(pNode);
        }

        public void RemoveState(StateNode pNode)
        {
            StateList.Remove(pNode);
        }
    }
}