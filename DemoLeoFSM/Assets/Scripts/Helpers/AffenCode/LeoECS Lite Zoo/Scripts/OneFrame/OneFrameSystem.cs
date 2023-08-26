using Leopotam.EcsLite;

namespace Helpers.AffenCode.LeoECS_Lite_Zoo.Scripts.OneFrame
{
    public sealed class OneFrameSystem<T> : IEcsRunSystem where T : struct
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<T>().End();
            var oneFrames = world.GetPool<T>();
            foreach (var entity in filter)
            {
                oneFrames.Del(entity);
            }
        }
    }
}