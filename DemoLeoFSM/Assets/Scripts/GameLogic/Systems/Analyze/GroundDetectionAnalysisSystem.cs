using System;
using GameLogic.Components;
using GameLogic.Components.Grounds;
using GameLogic.Components.Hit;
using GameLogic.Components.Owners;
using Leopotam.EcsLite;
using UniRx;
using UnityEngine;

namespace GameLogic.Systems.Analyze
{
    /// <summary>
    /// The system reactively analyzes the detection of the ground and sets boolean flags depending on the detection result
    /// </summary>
    internal class GroundDetectionAnalysisSystem : IEcsRunSystem, IEcsInitSystem, IDisposable
    {
        private EcsWorld _defaultWorld;
        private EcsFilter _filter;
        private EcsPool<Grounded> _grounded;
        private EcsPool<OwnerComponent> _owners;
        private EcsPool<ReactiveIsHit> _reactiveIsHits;
        private readonly CompositeDisposable _compositeDisposable = new CompositeDisposable();

        public void Init(IEcsSystems systems)
        {
            _defaultWorld = systems.GetWorld();

            _filter = _defaultWorld.Filter<AnalysisDetectionReactiveMarker>().Inc<GroundPointMarker>()
                .Inc<OwnerComponent>()
                .Inc<ReactiveIsHit>().End();

            _grounded = _defaultWorld.GetPool<Grounded>();
            _owners = _defaultWorld.GetPool<OwnerComponent>();
            _reactiveIsHits = _defaultWorld.GetPool<ReactiveIsHit>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter)
            {
                _reactiveIsHits.Get(entity).value.Subscribe(value =>
                {
                    if (TryUnpack(entity, out int ownerEntity))
                        _grounded.Get(ownerEntity).value = value;
                }).AddTo(_compositeDisposable);
            }
        }

        private bool TryUnpack(int entity, out int ownerEntity) =>
            _owners.Get(entity).Value.Unpack(out _defaultWorld, out ownerEntity);

        public void Dispose()
        {
            Debug.Log("Dispose");
            _compositeDisposable.Dispose();
        }
    }
}