using Components.EngineComponents;
using Components.Movement;
using Leopotam.EcsLite;
using UnityEngine;

namespace Systems.Movements
{
    internal class DirectionCalculationSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _defaultWorld;
        private EcsFilter _filter;
        private EcsPool<RigidbodyComponent> _rigidbodies;
        private EcsPool<Destination> _destinations;
        private EcsPool<MovementDirection> _movementDirections;

        public void Init(IEcsSystems systems)
        {
            _defaultWorld = systems.GetWorld();

            _filter = _defaultWorld.Filter<MovementDirection>().Inc<Destination>().Inc<RigidbodyComponent>().End();

            _movementDirections = _defaultWorld.GetPool<MovementDirection>();
            _destinations = _defaultWorld.GetPool<Destination>();
            _rigidbodies = _defaultWorld.GetPool<RigidbodyComponent>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter)
            {
                ref var rigidbodyComponent = ref _rigidbodies.Get(entity);
                ref var destination = ref _destinations.Get(entity);
                ref var movementDirection = ref _movementDirections.Get(entity);

                movementDirection.direction = ((Vector2) destination.value.position - rigidbodyComponent.value.position)
                    .normalized;
            }
        }
    }
}