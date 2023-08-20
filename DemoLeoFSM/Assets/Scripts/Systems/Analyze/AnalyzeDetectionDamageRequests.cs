using Common;
using Components;
using Components.Buffers;
using Components.Performs;
using Components.Requests.Self;
using Infrastructure.Services.Factories.Requests.Damage;
using Leopotam.EcsLite;
using UnityComponents.Views;
using UnityEngine;

namespace Systems.Analyze
{
    /// <summary>
    /// The system creates requests for damage depending on the number of hits in the overlap zone
    /// </summary>
    internal class AnalyzeDetectionDamageRequests : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld _defaultWorld;
        private EcsWorld _eventsWorld;
        private EcsFilter _filter;
        private EcsPool<HitBuffer> _hitBuffers;
        private readonly IDamageRequestFactory _damageRequestFactory;
        private EcsPool<AnalyzeDetectionSelfRequest> _analyzeRequests;
        private EcsPool<PerformDetection> _performDetections;

        public AnalyzeDetectionDamageRequests(IDamageRequestFactory damageRequestFactory) =>
            _damageRequestFactory = damageRequestFactory;

        public void Init(IEcsSystems systems)
        {
            _defaultWorld = systems.GetWorld();
            _eventsWorld = systems.GetWorld(WorldsNames.EventsWorldName);

            _filter = _defaultWorld.Filter<DamageAnalyzeMarker>().Inc<HitBuffer>().Inc<AnalyzeDetectionSelfRequest>()
                .End();

            _hitBuffers = _defaultWorld.GetPool<HitBuffer>();
            _analyzeRequests = _defaultWorld.GetPool<AnalyzeDetectionSelfRequest>();
            _performDetections = _defaultWorld.GetPool<PerformDetection>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter)
            {
                ref var hitBuffer = ref _hitBuffers.Get(entity);
                
                Debug.Log("start analyze");

                _performDetections.Del(entity);
                
                foreach (Collider2D hit in hitBuffer.value)
                {
                    if (!hit.TryGetComponent(out EntityView entityView))
                        continue;

                    _damageRequestFactory.CreateDamageRequest(_defaultWorld, _eventsWorld, entity,
                        entityView.Entity);

                    _analyzeRequests.Del(entity);
                    Debug.Log("analyze");
                }
            }
        }
    }
}