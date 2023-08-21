using GameLogic.Components.EngineComponents;
using GameLogic.Components.Requests.Self;
using Leopotam.EcsLite;
using UnityEngine;

namespace GameLogic.Systems.Destroy
{
    internal class DestroyGameObjectSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _defaultWorld;
        private EcsFilter _filter;
        private EcsPool<TransformComponent> _transforms;

        public void Init(IEcsSystems systems)
        {
            _defaultWorld = systems.GetWorld();
            
            _filter = _defaultWorld.Filter<DestroyGameObjectSelfRequest>().Inc<TransformComponent>().End();

            _transforms = _defaultWorld.GetPool<TransformComponent>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter)
            {
                ref var transformComponent = ref  _transforms.Get(entity);
                
                Object.Destroy(transformComponent.value);
            }
        }
    }
}