using GameLogic.Components;
using Leopotam.EcsLite;

namespace GameLogic.Systems.Destroy
{
    internal class DestroyEntitySystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _defaultWorld;
        private EcsFilter _filter;

        public void Init(IEcsSystems systems)
        {
            _defaultWorld = systems.GetWorld();
            _filter = _defaultWorld.Filter<DestroyEntitySelfRequest>().End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter) 
                _defaultWorld.DelEntity(entity);
        }
    }
}