using Leopotam.EcsLite;
using UnityEngine;

namespace Helpers.ConverterToEntity
{
    public abstract class BaseConverterComponent : MonoBehaviour
    {
        public abstract void ConvertToEntity(EcsWorld world, int entity);
    }
}