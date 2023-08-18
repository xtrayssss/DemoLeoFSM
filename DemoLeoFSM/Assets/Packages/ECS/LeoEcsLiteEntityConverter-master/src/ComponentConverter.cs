using Leopotam.EcsLite.Packages.ECS.src;
using UnityEngine;

namespace Packages.ECS.src
{
    [DisallowMultipleComponent]
    public class ComponentConverter<T> : BaseConverter where T : struct
    {
        [SerializeField] protected T _component;

        public override void Convert(EcsPackedEntityWithWorld entityWithWorld)
        {
            if (entityWithWorld.Unpack(out var world, out var entity))
            {
                ref var component = ref world.GetPool<T>().Add(entity);
                component = _component;
            }
        }

        private void Reset()
        {
            var container = GetComponentInChildren<ComponentsContainer>();
            container.GetConverters();
        }
    }
}