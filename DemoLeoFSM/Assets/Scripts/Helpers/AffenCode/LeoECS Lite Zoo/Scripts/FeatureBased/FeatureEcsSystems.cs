using System.Collections.Generic;

namespace Helpers.AffenCode.LeoECS_Lite_Zoo.Scripts.FeatureBased
{
    public sealed class FeatureEcsSystems
    {
        private readonly EcsSystemsData _systemsData;

        private readonly List<BaseEcsFeature> _features = new List<BaseEcsFeature>();

        public FeatureEcsSystems(EcsSystemsData systemsData) =>
            _systemsData = systemsData;

        public FeatureEcsSystems Add(BaseEcsFeature feature)
        {
            feature.AddInitSystems(_systemsData.InitSystems);
            feature.AddUpdateSystems(_systemsData.UpdateSystems);
            feature.AddFixedUpdateSystems(_systemsData.FixedUpdateSystems);
            feature.AddLateUpdateSystems(_systemsData.LateUpdateSystems);
            
            _features.Add(feature);

            return this;
        }

        public FeatureEcsSystems End()
        {
            foreach (BaseEcsFeature feature in _features)
            {
                feature.AddUpdateOneFrames(_systemsData.UpdateSystems);
                feature.AddFixedUpdateOneFrames(_systemsData.FixedUpdateSystems);
                feature.AddLateUpdateOneFrames(_systemsData.LateUpdateSystems);
            }

            return this;
        }
    }
}