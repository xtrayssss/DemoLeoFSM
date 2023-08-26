using GameLogic.Components;
using GameLogic.Components.Performs;
using Leopotam.EcsLite;

namespace GameLogic.Systems.Detection
{
    internal class StartDetectionSystem
    {
        private EcsWorld _defaultWorld;
        private EcsFilter _filter;
        private EcsPool<PerformDetection> _performDetections;

        public void Init(IEcsSystems systems)
        {
            _defaultWorld = systems.GetWorld();
            
            _filter = _defaultWorld.Filter<AfterDetection>().End();
            
            _performDetections = _defaultWorld.GetPool<PerformDetection>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter) 
                _performDetections.Add(entity);
        }
    }
}