using GameLogic.Skeletons.SkeletonFSM;
using Leopotam.EcsLite;

namespace GameLogic.Factories.Transition
{
    internal interface IStateMachineFactory
    {
        public int CreateStateMachine(EcsWorld world, State initializeState);
    }
}