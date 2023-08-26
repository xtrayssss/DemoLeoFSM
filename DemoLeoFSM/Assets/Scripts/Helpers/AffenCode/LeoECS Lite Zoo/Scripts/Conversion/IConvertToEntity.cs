using Leopotam.EcsLite;

namespace Helpers.AffenCode.LeoECS_Lite_Zoo.Scripts.Conversion
{
    public interface IConvertToEntity
    {
        void ConvertToEntity(EcsWorld ecsWorld, int entity);
    }
}