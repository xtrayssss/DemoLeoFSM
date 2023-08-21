using Common;
using GameLogic.Components.EngineComponents;
using GameLogic.Components.Requests.Other;
using Leopotam.EcsLite;
using UnityEngine;

namespace GameLogic.Systems.Updates
{
    internal class UpdateMovementVelocitySystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld _defaultWorld;
        private EcsWorld _eventsWorld;
        private EcsFilter _filter;
        private EcsPool<RigidbodyComponent> _rigidbodies;
        private EcsPool<UpdateMovementVelocityRequest> _updateVelocityRequests;
        private Vector2 _velocity;

        public void Init(IEcsSystems systems)
        {
            _defaultWorld = systems.GetWorld();
            _eventsWorld = systems.GetWorld(WorldsNames.EventsWorldName);
            _filter = _eventsWorld.Filter<UpdateMovementVelocityRequest>().End();
            _rigidbodies = _defaultWorld.GetPool<RigidbodyComponent>();
            _updateVelocityRequests = _eventsWorld.GetPool<UpdateMovementVelocityRequest>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter)
            {
                ref var resetMovementVelocityRequest = ref _updateVelocityRequests.Get(entity);

                if (TryUnpack(resetMovementVelocityRequest, out int targetEntity, out _))
                {
                    ref var rigidbodyComponent = ref _rigidbodies.Get(targetEntity);
                    _velocity.Set(resetMovementVelocityRequest.Value, rigidbodyComponent.value.velocity.y);
                    rigidbodyComponent.value.velocity = _velocity;
                }

                _eventsWorld.DelEntity(entity);
            }
        }

        private bool TryUnpack(UpdateMovementVelocityRequest updateMovementVelocityRequest, out int targetEntity,
            out EcsWorld world) =>
            updateMovementVelocityRequest.TargetEntity.Unpack(out world, out targetEntity);
    }
}