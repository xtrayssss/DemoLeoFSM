using GameLogic.Components;
using Leopotam.EcsLite;

namespace GameLogic.Systems.Detection
{
    internal class DeleteAfterDetection : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _defaultWorld;
        private EcsFilter _filter;
        private EcsPool<AfterDetection> _afterDetections;

        public void Init(IEcsSystems systems)
        {
            _defaultWorld = systems.GetWorld();

            _filter = _defaultWorld.Filter<AfterDetection>().End();
            
            _afterDetections = _defaultWorld.GetPool<AfterDetection>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter) 
                _afterDetections.Del(entity);
        }
    }
}