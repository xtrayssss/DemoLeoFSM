using System;
using System.Collections.Generic;
using GameLogic.Skeletons.SkeletonFSM;
using Leopotam.EcsLite;

namespace GameLogic.Factories.Transition
{
    internal interface ITransitionFactory
    {
        public int CreateTransition(EcsWorld world, State fromState, State toState, Func<bool> condition, int ownerEntity);
        public int CreateGroupTransition(EcsWorld world, State toState, Func<bool> condition, HashSet<State> groupStates, int ownerEntity);
    }
}