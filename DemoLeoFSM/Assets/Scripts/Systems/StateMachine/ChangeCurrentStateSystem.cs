using Common;
using Components.Requests.Self;
using Components.Transition;
using Leopotam.EcsLite;

namespace Systems.StateMachine
{
    internal class ChangeCurrentStateSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _statesWorld;
        private EcsFilter _filter;
        private EcsPool<CurrentState> _currentStates;
        private EcsPool<SwitchStateSelfRequest> _switchRequests;
        private EcsPool<SetupTransitionsActivitySelfRequest> _setupRequests;
        private EcsPool<CleanupTransitionsActivitySelfRequest> _cleanupRequests;

        public void Init(IEcsSystems systems)
        {
            _statesWorld = systems.GetWorld(WorldsNames.StatesWorldName);

            _filter = _statesWorld.Filter<CurrentState>().Inc<SwitchStateSelfRequest>().End();

            _currentStates = _statesWorld.GetPool<CurrentState>();
            _switchRequests = _statesWorld.GetPool<SwitchStateSelfRequest>();
            _setupRequests = _statesWorld.GetPool<SetupTransitionsActivitySelfRequest>();
            _cleanupRequests = _statesWorld.GetPool<CleanupTransitionsActivitySelfRequest>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter)
            {
                ref var switchStateSelfRequest = ref _switchRequests.Get(entity);
                ref var currentState = ref _currentStates.Get(entity);

                if (currentState.Value != null)
                {
                    _cleanupRequests.Add(entity).Value = currentState.Value;
                    currentState.Value.Exit();
                }

                currentState.Value = switchStateSelfRequest.TargetState;

                _setupRequests.Add(entity).Value = currentState.Value;

                currentState.Value.Enter();

                _switchRequests.Del(entity);
            }
        }
    }
}