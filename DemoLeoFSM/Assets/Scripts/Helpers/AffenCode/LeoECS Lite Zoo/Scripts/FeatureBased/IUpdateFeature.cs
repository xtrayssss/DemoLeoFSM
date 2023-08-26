using Leopotam.EcsLite;

namespace Helpers.AffenCode.LeoECS_Lite_Zoo.Scripts.FeatureBased
{
    public interface IUpdateFeature : IEcsFeature
    {
        public void Update(IEcsSystems ecsSystems);
    }
}