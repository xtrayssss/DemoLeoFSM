using Leopotam.EcsLite;

namespace Helpers.AffenCode.LeoECS_Lite_Zoo.Scripts.OneFrame
{
    public static class OneFrameEx
    {
        public static IEcsSystems OneFrame<T>(this IEcsSystems ecsSystems) where T : struct
        {
            ecsSystems.Add(new OneFrameSystem<T>());
            return ecsSystems;
        }
    }
}