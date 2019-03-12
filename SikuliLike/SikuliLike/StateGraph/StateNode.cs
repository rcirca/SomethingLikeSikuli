using System;
using SikuliLike.Util;
using SikuliLike.Util.Enums;

namespace SikuliLike.StateGraph
{
    public class StateNode : IEquatable<StateNode>
    {
        public StateNode(string pStateName, ImageLocation pImageLocation)
        {
            ImageLocation = pImageLocation;
            StateName = pStateName;
        }

        public string StateName { get; }
        public ImageLocation ImageLocation { get; }
        public Actions PerformAction { get; set; } = Actions.DoubleClickLocation;

        public bool Equals(StateNode pOtherNode)
        {
            return StateName.Equals(pOtherNode?.StateName);
        }
    }
}