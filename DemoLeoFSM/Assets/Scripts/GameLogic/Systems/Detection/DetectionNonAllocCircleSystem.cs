using GameLogic.Components;
using GameLogic.Components.Attack;
using GameLogic.Components.Buffers;
using GameLogic.Components.EngineComponents;
using GameLogic.Components.Hit;
using GameLogic.Components.Performs;
using Leopotam.EcsLite;
using UnityEngine;
using Range = GameLogic.Components.Attack.Range;

namespace GameLogic.Systems.Detection
{
    internal class DetectionNonAllocCircleSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld _defaultWorld;
        private EcsFilter _filter;
        private EcsPool<Range> _rangeAttacks;
        private EcsPool<HitLayer> _hitLayers;
        private EcsPool<HitBuffer> _hitBuffers;
        private EcsPool<TransformComponent> _transformComponents;
        private EcsPool<HitsCount> _hitsCounts;
        private EcsPool<IsHit> _isHits;
        private EcsPool<AfterDetection> _afterDetection;

        public void Init(IEcsSystems systems)
        {
            _defaultWorld = systems.GetWorld();

            _filter = _defaultWorld.Filter<Range>().Inc<HitLayer>().Inc<HitBuffer>().Inc<TransformComponent>()
                .Inc<HitsCount>().Inc<IsHit>().Inc<PerformDetection>().End();

            _rangeAttacks = _defaultWorld.GetPool<Range>();
            _hitLayers = _defaultWorld.GetPool<HitLayer>();
            _hitBuffers = _defaultWorld.GetPool<HitBuffer>();
            _transformComponents = _defaultWorld.GetPool<TransformComponent>();
            _hitsCounts = _defaultWorld.GetPool<HitsCount>();
            _isHits = _defaultWorld.GetPool<IsHit>();
            _afterDetection = _defaultWorld.GetPool<AfterDetection>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter)
            {
                ref var rangeAttack = ref _rangeAttacks.Get(entity);
                ref var hitLayer = ref _hitLayers.Get(entity);
                ref var hitBuffer = ref _hitBuffers.Get(entity);
                ref var transformComponent = ref _transformComponents.Get(entity);
                ref var hitsCount = ref _hitsCounts.Get(entity);

                hitsCount.value = Physics2D.OverlapCircleNonAlloc(transformComponent.value.position,
                    rangeAttack.value,
                    hitBuffer.value, hitLayer.value);

                _isHits.Get(entity).value = hitsCount.value != 0;

                _afterDetection.Add(entity);
                
                Debug.Log("detect " + hitsCount.value);
            }
        }
    }
}