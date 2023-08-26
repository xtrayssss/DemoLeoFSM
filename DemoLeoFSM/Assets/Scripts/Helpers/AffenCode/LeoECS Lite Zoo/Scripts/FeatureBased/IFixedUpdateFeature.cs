using Leopotam.EcsLite;

namespace Helpers.AffenCode.LeoECS_Lite_Zoo.Scripts.FeatureBased
{
    public interface IFixedUpdateFeature : IEcsFeature
    {
        public void FixedUpdate(IEcsSystems ecsSystems);
    }
}