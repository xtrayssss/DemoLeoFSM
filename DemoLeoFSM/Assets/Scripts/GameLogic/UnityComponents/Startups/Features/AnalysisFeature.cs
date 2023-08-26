using GameLogic.Components;
using GameLogic.Components.Requests.Self;
using GameLogic.Factories.Requests.Damage;
using GameLogic.Systems.Analyze;
using Helpers.AffenCode.LeoECS_Lite_Zoo.Scripts.FeatureBased;
using Helpers.AffenCode.LeoECS_Lite_Zoo.Scripts.OneFrame;
using Leopotam.EcsLite;

namespace GameLogic.UnityComponents.Startups.Features
{
    public class AnalysisFeature : BaseEcsFeature
    {
        private readonly IDamageRequestFactory _damageRequestFactory;

        public AnalysisFeature(IDamageRequestFactory damageRequestFactory) =>
            _damageRequestFactory = damageRequestFactory;

        public override void AddUpdateSystems(IEcsSystems systems) =>
            systems
                .Add(new CreationAnalysisRequestWhenHitSystem())
                .Add(new DamageDetectionAnalysisSystem(_damageRequestFactory))
                .Add(new GroundDetectionAnalysisSystem());

        public override void AddUpdateOneFrames(IEcsSystems systems) =>
            systems
                .OneFrame<AnalysisDetectionSelfRequest>()
                .OneFrame<AnalysisDetectionReactiveMarker>();
    }
}