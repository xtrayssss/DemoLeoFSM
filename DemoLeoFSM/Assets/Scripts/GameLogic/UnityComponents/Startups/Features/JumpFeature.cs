using GameLogic.Systems.Jump;
using GameLogic.Systems.Updates;
using Helpers.AffenCode.LeoECS_Lite_Zoo.Scripts.FeatureBased;
using Leopotam.EcsLite;

namespace GameLogic.UnityComponents.Startups.Features
{
    public class JumpFeature : BaseEcsFeature
    {
        public override void AddFixedUpdateSystems(IEcsSystems systems) =>
            systems
                .Add(new JumpSystem());

        public override void AddUpdateSystems(IEcsSystems systems) =>
            systems
                .Add(new UpdateJumpVelocitySystem());
    }
}