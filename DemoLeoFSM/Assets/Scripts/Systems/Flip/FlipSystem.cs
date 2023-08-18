using System.Threading.Tasks;
using Components.Movement;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Packages.ECS.src;
using UnityEngine;

namespace Systems.Flip
{
    internal class FlipSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld _world;
        private EcsFilter _filter;
        private EcsPool<MovementDirection> _movementDirections;
        private EcsPool<Components.Flip.Flip> _flips;
        
        private readonly Vector3 _leftFacingDirection = new Vector3(-1, 1, 1);
        private readonly Vector3 _rightFacingDirection = new Vector3(1, 1, 1);

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<Components.Flip.Flip>().Inc<MovementDirection>().End();
            _movementDirections = _world.GetPool<MovementDirection>();
            _flips = _world.GetPool<Components.Flip.Flip>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter)
            {
                ref var movementDirection = ref _movementDirections.Get(entity);
                ref var flip = ref _flips.Get(entity);

                if (IsMoving(movementDirection))
                    flip.value.localScale = movementDirection.direction.x > 0.0f
                        ? _rightFacingDirection
                        : _leftFacingDirection;
            }
        }

        private bool IsMoving(MovementDirection movementDirection) => 
            movementDirection.direction.x != 0.0f;
    }
}