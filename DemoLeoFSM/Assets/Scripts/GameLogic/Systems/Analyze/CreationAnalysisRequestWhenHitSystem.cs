using GameLogic.Components;
using GameLogic.Components.Hit;
using GameLogic.Components.Requests.Self;
using Leopotam.EcsLite;

namespace GameLogic.Systems.Analyze
{
    /// <summary>
    /// The system detects whether there was a blow and if there was, then creates a request for analysis
    /// </summary>
    internal class CreationAnalysisRequestWhenHitSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _defaultWorld;
        private EcsFilter _filter;
        private EcsPool<IsHit> _isHits;
        private EcsPool<AnalysisDetectionSelfRequest> _analysisDetectionRequests;

        public void Init(IEcsSystems systems)
        {
            _defaultWorld = systems.GetWorld();

            _filter = _defaultWorld.Filter<IsHit>().Inc<AnalysisDetectionWhenHitMarker>().Inc<AfterDetection>().End();

            _isHits = _defaultWorld.GetPool<IsHit>();
            _analysisDetectionRequests = _defaultWorld.GetPool<AnalysisDetectionSelfRequest>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter)
            {
                if (HasHit(entity))
                {
                    _isHits.Get(entity).value = false;
                    
                    _analysisDetectionRequests.Add(entity);
                }
            }
        }

        private bool HasHit(int entity) =>
            _isHits.Get(entity).value;
    }
}