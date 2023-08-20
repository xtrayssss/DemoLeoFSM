using Components.Attack;
using Components.Buffers;
using Components.EngineComponents;
using Components.Hit;
using Components.Performs;
using Leopotam.EcsLite;
using UnityEngine;
using Range = Components.Attack.Range;

namespace Systems.Detection
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

        public void Init(IEcsSystems systems)
        {
            _defaultWorld = systems.GetWorld();

            _filter = _defaultWorld.Filter<Range>().Inc<HitLayer>().Inc<HitBuffer>().Inc<TransformComponent>()
                .Inc<HitsCount>().Inc<PerformDetection>().End();

            _rangeAttacks = _defaultWorld.GetPool<Range>();
            _hitLayers = _defaultWorld.GetPool<HitLayer>();
            _hitBuffers = _defaultWorld.GetPool<HitBuffer>();
            _transformComponents = _defaultWorld.GetPool<TransformComponent>();
            _hitsCounts = _defaultWorld.GetPool<HitsCount>();
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
                
                Debug.Log("detect");
            }
        }
    }
}