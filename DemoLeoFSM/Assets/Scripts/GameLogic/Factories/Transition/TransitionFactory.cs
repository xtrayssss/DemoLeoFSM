using System;
using System.Collections.Generic;
using GameLogic.Components.Owners;
using GameLogic.Components.Transition;
using GameLogic.Skeletons.SkeletonFSM;
using Leopotam.EcsLite;

namespace GameLogic.Factories.Transition
{
    internal class TransitionFactory : ITransitionFactory
    {
        public int CreateTransition(EcsWorld world, State fromState, State toState, Func<bool> condition,
            int ownerEntity)
        {
            int entity = world.NewEntity();

            world.GetPool<ConditionTransition>().Add(entity).Value = condition;
            world.GetPool<FromState>().Add(entity).Value = fromState;
            world.GetPool<TargetState>().Add(entity).Value = toState;
            world.GetPool<OwnerComponent>().Add(entity).Value = world.PackEntityWithWorld(ownerEntity);

            return entity;
        }

        public int CreateGroupTransition(EcsWorld world, State toState, Func<bool> condition, HashSet<State> groupStates, int ownerEntity)
        {
            int entity = world.NewEntity();

            world.GetPool<ConditionTransition>().Add(entity).Value = condition;
            world.GetPool<TargetState>().Add(entity).Value = toState;
            world.GetPool<OwnerComponent>().Add(entity).Value = world.PackEntityWithWorld(ownerEntity);
            world.GetPool<GroupStates>().Add(entity).Value = groupStates;
           
            return entity;
        }
    }
}