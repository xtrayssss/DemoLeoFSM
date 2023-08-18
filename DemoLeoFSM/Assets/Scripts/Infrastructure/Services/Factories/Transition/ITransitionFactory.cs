using System;
using System.Collections.Generic;
using FSM;
using Leopotam.EcsLite.Packages.ECS.src;

namespace Infrastructure.Services.Factories.Transition
{
    internal interface ITransitionFactory
    {
        public int CreateTransition(EcsWorld world, State fromState, State toState, Func<bool> condition, int ownerEntity);
        public int CreateGroupTransition(EcsWorld world, State toState, Func<bool> condition, HashSet<State> groupStates, int ownerEntity);
    }
}