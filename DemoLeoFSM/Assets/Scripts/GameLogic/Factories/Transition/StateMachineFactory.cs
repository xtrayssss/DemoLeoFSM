using System.Collections.Generic;
using GameLogic.Components;
using GameLogic.Components.Transition;
using GameLogic.Skeletons.SkeletonFSM;
using Leopotam.EcsLite;

namespace GameLogic.Factories.Transition
{
    internal class StateMachineFactory : IStateMachineFactory
    {
        public int CreateStateMachine(EcsWorld world, State initializeState)
        {
            int entity = world.NewEntity();
            
            world.GetPool<PackTransitions>().Add(entity).Value = new Dictionary<State, int[]>();
            
            world.GetPool<CurrentState>().Add(entity);
       
            world.GetPool<SwitchStateSelfRequest>().Add(entity).TargetState =
                initializeState;

            return entity;
        }
    }
}