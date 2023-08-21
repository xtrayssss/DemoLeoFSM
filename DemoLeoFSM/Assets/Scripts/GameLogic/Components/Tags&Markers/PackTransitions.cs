using System.Collections.Generic;
using GameLogic.Skeletons.SkeletonFSM;

namespace GameLogic.Components
{
    internal struct PackTransitions
    {
        public Dictionary<State, int[]> Value;
    }
}