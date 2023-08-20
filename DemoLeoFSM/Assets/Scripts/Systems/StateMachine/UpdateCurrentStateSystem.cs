using Common;
using Components.Transition;
using Leopotam.EcsLite;

namespace Systems.StateMachine
{
    internal class UpdateCurrentStateSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _statesWorldName;
        private EcsFilter _filter;
        private EcsPool<CurrentState> _currentStates;

        public void Init(IEcsSystems systems)
        {
            _statesWorldName = systems.GetWorld(WorldsNames.StatesWorldName);

            _filter = _statesWorldName.Filter<CurrentState>().End();

            _currentStates = _statesWorldName.GetPool<CurrentState>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter) 
                _currentStates.Get(entity).Value.LogicUpdate();
        }
    }
}