using System.Collections.Generic;
using FSM;
using Leopotam.EcsLite.Packages.ECS.src;

namespace Infrastructure.Services.Factories.Transition
{
    internal interface IStateMachineFactory
    {
        public int CreateStateMachine(EcsWorld world, State initializeState);
    }
}