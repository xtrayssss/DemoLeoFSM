using FSM;
using Leopotam.EcsLite;

namespace Infrastructure.Services.Factories.Transition
{
    internal interface IStateMachineFactory
    {
        public int CreateStateMachine(EcsWorld world, State initializeState);
    }
}