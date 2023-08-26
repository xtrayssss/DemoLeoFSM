using Leopotam.EcsLite;

namespace Helpers.AffenCode.LeoECS_Lite_Zoo.Scripts.FeatureBased
{
    public class EcsSystemsData
    {
        public IEcsSystems UpdateSystems;
        public IEcsSystems InitSystems;
        public IEcsSystems FixedUpdateSystems;
        public IEcsSystems LateUpdateSystems;
    }
}