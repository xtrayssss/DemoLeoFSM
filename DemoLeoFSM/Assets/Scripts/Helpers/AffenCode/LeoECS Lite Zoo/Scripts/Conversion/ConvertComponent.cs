using Leopotam.EcsLite;
using UnityEngine;

namespace Helpers.AffenCode.LeoECS_Lite_Zoo.Scripts.Conversion
{
    [RequireComponent(typeof(ConvertToEntity))]
    public abstract class ConvertComponent<T> : MonoBehaviour, IConvertToEntity where T : struct
    {
        public T Value;
        
        public void ConvertToEntity(EcsWorld ecsWorld, int entity)
        {
            var pool = ecsWorld.GetPool<T>();
            pool.Add(entity) = Value;
        }
    }
}