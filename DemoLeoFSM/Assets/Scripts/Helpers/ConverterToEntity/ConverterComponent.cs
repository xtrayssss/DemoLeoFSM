using Leopotam.EcsLite;
using UnityEngine;

namespace Helpers.ConverterToEntity
{
    public abstract class ConverterComponent<TComponent> : BaseConverterComponent where TComponent : struct
    {
        [SerializeField] protected TComponent Component;

        public override void ConvertToEntity(EcsWorld world, int entity) => 
            world.GetPool<TComponent>().Add(entity) = Component;
    }
}