using GameLogic.Components.Attack;
using GameLogic.Components.EngineComponents;
using GameLogic.Components.Hit;
using GameLogic.Components.Performs;
using GameLogic.Components.Requests.Self;
using Leopotam.EcsLite;
using UnityEngine;
using Range = GameLogic.Components.Attack.Range;

namespace GameLogic.Systems.Detection
{
    internal class DetectionCircleSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld _defaultWorld;
        private EcsFilter _filter;
        private EcsPool<CircleOverlapAnalyzeSelfRequest> _analyzeRequests;
        private EcsPool<Range> _ranges;
        private EcsPool<HitLayer> _hitLayers;
        private EcsPool<Hit> _hits;
        private EcsPool<TransformComponent> _transformComponents;

        public void Init(IEcsSystems systems)
        {
            _defaultWorld = systems.GetWorld();

            _filter = _defaultWorld.Filter<Range>().Inc<HitLayer>().Inc<Hit>().Inc<TransformComponent>()
                .Inc<PerformDetection>().End();

            _ranges = _defaultWorld.GetPool<Range>();
            _hitLayers = _defaultWorld.GetPool<HitLayer>();
            _hits = _defaultWorld.GetPool<Hit>();
            _transformComponents = _defaultWorld.GetPool<TransformComponent>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter)
            {
                ref var range = ref _ranges.Get(entity);
                ref var hitLayer = ref _hitLayers.Get(entity);
                ref var hit = ref _hits.Get(entity);
                ref var transformComponent = ref _transformComponents.Get(entity);

                hit.value = Physics2D.OverlapCircle(transformComponent.value.position,
                    range.value,
                    hitLayer.value);
            }
        }
    }
}