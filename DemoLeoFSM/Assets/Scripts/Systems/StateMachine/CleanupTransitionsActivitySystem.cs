using Common;
using Components;
using Components.Requests.Self;
using Leopotam.EcsLite;

namespace Systems.StateMachine
{
    internal class CleanupTransitionsActivitySystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _statesWorld;
        private EcsFilter _filter;
        private EcsPool<PackTransitions> _packagesTransitions;
        private EcsPool<ActiveMarker> _activeMarkers;
        private EcsPool<CleanupTransitionsActivitySelfRequest> _cleanupRequests;

        public void Init(IEcsSystems systems)
        {
            _statesWorld = systems.GetWorld(WorldsNames.StatesWorldName);

            _filter = _statesWorld.Filter<PackTransitions>().Inc<CleanupTransitionsActivitySelfRequest>().End();

            _packagesTransitions = _statesWorld.GetPool<PackTransitions>();
            _activeMarkers = _statesWorld.GetPool<ActiveMarker>();
            _cleanupRequests = _statesWorld.GetPool<CleanupTransitionsActivitySelfRequest>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter)
            {
                ref var packTransitions = ref _packagesTransitions.Get(entity);
                ref var cleanupRequest = ref _cleanupRequests.Get(entity);

                foreach (int transitionEntity in packTransitions.Value[cleanupRequest.Value])
                    _activeMarkers.Del(transitionEntity);

                _cleanupRequests.Del(entity);
            }
        }
    }
}