using GameLogic.Components;
using GameLogic.Components.Performs;
using Leopotam.EcsLite;

namespace GameLogic.Systems.Detection
{
    /// <summary>
    /// The system stops the detection
    /// </summary>
    internal class StopDetectionSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _defaultWorld;
        private EcsFilter _filter;
        private EcsPool<PerformDetection> _performDetections;
        
        public void Init(IEcsSystems systems)
        {
            _defaultWorld = systems.GetWorld();

            _filter = _defaultWorld.Filter<AfterDetection>().Inc<SingleDetectionMarker>().End();

            _performDetections = _defaultWorld.GetPool<PerformDetection>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter)
                _performDetections.Del(entity);
        }
    }
}