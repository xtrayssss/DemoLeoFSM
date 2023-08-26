using Helpers.AffenCode.LeoECS_Lite_Zoo.Scripts.Conversion;
using UnityEngine;

namespace Helpers.AffenCode.LeoECS_Lite_Zoo.Scripts.Extensions
{
    public static class UnityEx
    {
        public static bool TryGetEntity(this GameObject gameObject, out int entity)
        {
            var convertToEntity = gameObject.GetComponentInParent<ConvertToEntity>();
            if (!convertToEntity)
            {
                entity = default;
                return false;
            }

            var nullableEntity = convertToEntity.GetEntity();
            if (!nullableEntity.HasValue)
            {
                entity = default;
                return false;
            }
            
            entity = nullableEntity.Value;
            return true;
        }
        
        public static bool TryGetEntity(this Component component, out int entity)
        {
            var convertToEntity = component.GetComponentInParent<ConvertToEntity>();
            if (!convertToEntity)
            {
                entity = default;
                return false;
            }

            var nullableEntity = convertToEntity.GetEntity();
            if (!nullableEntity.HasValue)
            {
                entity = default;
                return false;
            }
            
            entity = nullableEntity.Value;
            return true;
        }
    }
}