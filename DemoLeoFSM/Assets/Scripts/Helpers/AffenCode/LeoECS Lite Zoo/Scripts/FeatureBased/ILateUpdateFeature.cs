using Leopotam.EcsLite;

namespace Helpers.AffenCode.LeoECS_Lite_Zoo.Scripts.FeatureBased
{
    interface ILateUpdateFeature
    {
        public void LateUpdate(IEcsSystems ecsSystems);
    }
}