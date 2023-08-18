using System.Collections.Generic;
using Components;
using Components.Transition;
using FSM;
using Leopotam.EcsLite.Packages.ECS.src;

namespace Infrastructure.Services.Factories.Transition
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