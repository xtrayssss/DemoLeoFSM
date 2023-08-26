using GameLogic.Systems.Detection;
using Helpers.AffenCode.LeoECS_Lite_Zoo.Scripts.FeatureBased;
using Leopotam.EcsLite;

namespace GameLogic.UnityComponents.Startups.Features
{
    public class DetectionFeature : BaseEcsFeature
    {
        public override void AddFixedUpdateSystems(IEcsSystems systems) =>
            systems
                .Add(new CircleDetectionSystem())
                .Add(new DetectionNonAllocCircleSystem());

        public override void AddUpdateSystems(IEcsSystems systems) =>
            systems
                .Add(new StopDetectionSystem());
    }
}