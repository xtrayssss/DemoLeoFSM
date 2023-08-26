using GameLogic.Components.Requests.Self;
using GameLogic.Systems.Destroy;
using GameLogic.Systems.Detection;
using Helpers.AffenCode.LeoECS_Lite_Zoo.Scripts.FeatureBased;
using Helpers.AffenCode.LeoECS_Lite_Zoo.Scripts.OneFrame;
using Leopotam.EcsLite;

namespace GameLogic.UnityComponents.Startups.Features
{
    public class DestroyFeature : BaseEcsFeature
    {
        public override void AddUpdateSystems(IEcsSystems systems) =>
            systems
                .Add(new DeleteAfterDetection())
                .Add(new DestroyGameObjectSystem())
                .Add(new DestroyEntitySystem());

        public override void AddUpdateOneFrames(IEcsSystems systems) =>
            systems
                .OneFrame<DestroyGameObjectSelfRequest>();
    }
}