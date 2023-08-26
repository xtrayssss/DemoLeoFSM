using GameLogic.Components.Attack;
using GameLogic.Components.EngineComponents;
using GameLogic.Components.Hit;
using GameLogic.Components.Performs;
using Leopotam.EcsLite;
using UnityEngine;
using Range = GameLogic.Components.Attack.Range;

namespace GameLogic.Systems.Detection
{
    /// <summary>
    /// The system will detect a hit
    /// </summary>
    internal class CircleDetectionSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld _defaultWorld;
        private EcsFilter _filter;
        private EcsPool<Range> _ranges;
        private EcsPool<HitLayer> _hitLayers;
        private EcsPool<HitCollider> _hits;
        private EcsPool<TransformComponent> _transformComponents;
        private EcsPool<ReactiveIsHit> _reactiveIsHits;
        private EcsPool<IsHit> _isHits;

        public void Init(IEcsSystems systems)
        {
            _defaultWorld = systems.GetWorld();

            _filter = _defaultWorld.Filter<Range>().Inc<HitLayer>().Inc<HitCollider>().Inc<TransformComponent>()
                .Inc<PerformDetection>().Inc<ReactiveIsHit>().End();

            _ranges = _defaultWorld.GetPool<Range>();
            _hitLayers = _defaultWorld.GetPool<HitLayer>();
            _hits = _defaultWorld.GetPool<HitCollider>();
            _transformComponents = _defaultWorld.GetPool<TransformComponent>();
            _reactiveIsHits = _defaultWorld.GetPool<ReactiveIsHit>();
            _isHits = _defaultWorld.GetPool<IsHit>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter)
            {
                ref var range = ref _ranges.Get(entity);
                ref var hitLayer = ref _hitLayers.Get(entity);
                ref var transformComponent = ref _transformComponents.Get(entity);

                Collider2D hitCollider = OverlapCircle(transformComponent, range, hitLayer);

                _hits.Get(entity).value = hitCollider;

                _reactiveIsHits.Get(entity).value.Value = hitCollider;

                _isHits.Get(entity).value = hitCollider;
            }
        }

        private Collider2D OverlapCircle(TransformComponent transformComponent, Range range, HitLayer hitLayer) =>
            Physics2D.OverlapCircle(transformComponent.value.position, range.value, hitLayer.value);
    }
}