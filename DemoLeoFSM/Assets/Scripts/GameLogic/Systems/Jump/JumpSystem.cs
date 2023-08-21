using GameLogic.Components.EngineComponents;
using GameLogic.Components.Jump;
using Leopotam.EcsLite;
using UnityEngine;

namespace GameLogic.Systems.Jump
{
    internal class JumpSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsFilter _filter;
        private EcsPool<RigidbodyComponent> _rigidbodies;
        private EcsPool<JumpGravity> _jumpGravities;
        private EcsPool<JumpVelocity> _jumpVelocities;
        private Vector2 _jumpDirection;

        public void Init(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            _filter = world.Filter<JumpGravity>().Inc<RigidbodyComponent>().Inc<JumpVelocity>().Inc<PerformJump>()
                .End();

            _rigidbodies = world.GetPool<RigidbodyComponent>();
            _jumpGravities = world.GetPool<JumpGravity>();
            _jumpVelocities = world.GetPool<JumpVelocity>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter)
            {
                ref var jump = ref _jumpGravities.Get(entity);
                ref var rigidbodyComponent = ref _rigidbodies.Get(entity);
                ref var jumpVelocity = ref _jumpVelocities.Get(entity);

                jumpVelocity.value += jump.value * Time.fixedDeltaTime;

                _jumpDirection.Set(rigidbodyComponent.value.velocity.x, jumpVelocity.value * Time.deltaTime);
                
                rigidbodyComponent.value.velocity = _jumpDirection;
            }
        }
    }
}