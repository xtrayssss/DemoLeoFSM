using System.Threading.Tasks;
using Common;
using Components;
using Components.Requests.Self;
using Leopotam.EcsLite.Packages.ECS.src;

namespace Systems.StateMachine
{
    internal class SetupTransitionsActivitySystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _statesWorld;
        private EcsFilter _filter;
        private EcsPool<PackTransitions> _packagesTransitions;
        private EcsPool<ActiveMarker> _activeMarkers;
        private EcsPool<SetupTransitionsActivitySelfRequest> _setupRequests;

        public void Init(IEcsSystems systems)
        {
            _statesWorld = systems.GetWorld(WorldsNames.StatesWorldName);
            
            _filter = _statesWorld.Filter<PackTransitions>().Inc<SetupTransitionsActivitySelfRequest>().End();
            
            _packagesTransitions = _statesWorld.GetPool<PackTransitions>();            
            _activeMarkers = _statesWorld.GetPool<ActiveMarker>();            
            _setupRequests = _statesWorld.GetPool<SetupTransitionsActivitySelfRequest>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter)
            {
                ref var packTransitions = ref _packagesTransitions.Get(entity);
                ref var setupRequest = ref _setupRequests.Get(entity);

                foreach (int transitionEntity in packTransitions.Value[setupRequest.Value])
                    _activeMarkers.Add(transitionEntity);
                
                _setupRequests.Del(entity);
            }
        }
    }
}