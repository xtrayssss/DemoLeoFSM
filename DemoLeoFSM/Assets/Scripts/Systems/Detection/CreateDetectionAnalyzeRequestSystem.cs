using Components.Hit;
using Components.Performs;
using Components.Requests.Self;
using Leopotam.EcsLite;
using UnityEngine;

namespace Systems.Detection
{
    /// <summary>
    /// The system creates a request for detection analysis
    /// </summary>
    internal class CreateDetectionAnalyzeRequestSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _defaultWorld;
        private EcsFilter _filter;
        private EcsPool<HitsCount> _hitsCounts;
        private EcsPool<AnalyzeDetectionSelfRequest> _analyzeRequests;
        
        public void Init(IEcsSystems systems)
        {
            _defaultWorld = systems.GetWorld();

            _filter = _defaultWorld.Filter<HitsCount>().Inc<PerformDetection>().End();

            _hitsCounts = _defaultWorld.GetPool<HitsCount>();
            _analyzeRequests = _defaultWorld.GetPool<AnalyzeDetectionSelfRequest>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter)
            {
                if (HasHit(entity))
                    _analyzeRequests.Add(entity);
                
                Debug.Log("create");
            }
        }

        private bool HasHit(int entity) =>
            _hitsCounts.Get(entity).value != 0;
    }
}