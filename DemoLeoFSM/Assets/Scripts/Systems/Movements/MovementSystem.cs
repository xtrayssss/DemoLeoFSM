using System;
using System.Threading.Tasks;
using Components.EngineComponents;
using Components.Movement;
using Components.Performs;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Packages.ECS.src;
using UnityEngine;

namespace Systems.Movements
{
    internal class MovementSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsFilter _filter;

        private EcsPool<MovementDirection> _movementDirections;
        private EcsPool<MovementSpeed> _speeds;
        private EcsPool<RigidbodyComponent> _rigidbodies;

        public void Init(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            _filter = world.Filter<MovementDirection>().Inc<MovementSpeed>().Inc<RigidbodyComponent>()
                .Inc<PerformMovement>().End();

            _movementDirections = world.GetPool<MovementDirection>();
            _speeds = world.GetPool<MovementSpeed>();
            _rigidbodies = world.GetPool<RigidbodyComponent>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter)
            {
                ref var movementDirection = ref _movementDirections.Get(entity);
                ref var movementSpeed = ref _speeds.Get(entity);
                ref var rigidbodyComponent = ref _rigidbodies.Get(entity);

                movementDirection.movementVector.Set(
                    movementDirection.direction.x * (movementSpeed.value * Time.deltaTime),
                    rigidbodyComponent.value.velocity.y);

                rigidbodyComponent.value.velocity = movementDirection.movementVector;
            }
        }
    }
}