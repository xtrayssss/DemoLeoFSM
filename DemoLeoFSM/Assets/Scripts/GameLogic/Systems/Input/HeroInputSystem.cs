using GameLogic.Components;
using GameLogic.Components.Movement;
using GameLogic.Services.Input;
using Leopotam.EcsLite;

namespace GameLogic.Systems.Input
{
    internal class HeroInputSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsFilter _filter;
        private EcsPool<MovementDirection> _movementDirection;
        private EcsWorld _defaultWorld;
        private readonly IInputService _inputService;

        public HeroInputSystem(IInputService inputService) =>
            _inputService = inputService;

        public void Init(IEcsSystems systems)
        {
            _defaultWorld = systems.GetWorld();

            _filter = _defaultWorld.Filter<HeroTag>().Inc<MovementDirection>().End();

            _movementDirection = _defaultWorld.GetPool<MovementDirection>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter) 
                _movementDirection.Get(entity).direction = _inputService.MovementDirection;
        }
    }
}