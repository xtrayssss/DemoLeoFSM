using Common;
using GameLogic.Components;
using GameLogic.Components.Buffers;
using GameLogic.Components.Requests.Self;
using GameLogic.EntityViews;
using GameLogic.Factories.Requests.Damage;
using Leopotam.EcsLite;
using UnityEngine;

namespace GameLogic.Systems.Analyze
{
    /// <summary>
    /// The system creates requests for damage depending on the number of hits in the overlap zone
    /// </summary>
    internal class DamageDetectionAnalysisSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld _defaultWorld;
        private EcsWorld _eventsWorld;
        private EcsFilter _filter;
        private EcsPool<HitBuffer> _hitBuffers;
        private readonly IDamageRequestFactory _damageRequestFactory;

        public DamageDetectionAnalysisSystem(IDamageRequestFactory damageRequestFactory) =>
            _damageRequestFactory = damageRequestFactory;

        public void Init(IEcsSystems systems)
        {
            _defaultWorld = systems.GetWorld();
            _eventsWorld = systems.GetWorld(WorldsNames.EventsWorldName);

            _filter = _defaultWorld.Filter<DamageAnalysisMarker>().Inc<HitBuffer>().Inc<AnalysisDetectionSelfRequest>()
                .End();

            _hitBuffers = _defaultWorld.GetPool<HitBuffer>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter)
            {
                ref var hitBuffer = ref _hitBuffers.Get(entity);

                foreach (Collider2D hit in hitBuffer.value)
                {
                    Debug.Log("damage analysis");
                    if (!hit.TryGetComponent(out EntityView entityView))
                        continue;

                    _damageRequestFactory.CreateDamageRequest(_defaultWorld, _eventsWorld, entity,
                        entityView.Entity);
                }
            }
        }
    }
}