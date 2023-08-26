using GameLogic.Systems.Flip;
using GameLogic.Systems.Movements;
using GameLogic.Systems.Updates;
using Helpers.AffenCode.LeoECS_Lite_Zoo.Scripts.FeatureBased;
using Leopotam.EcsLite;

namespace GameLogic.UnityComponents.Startups.Features
{
    public class MovementFeature : BaseEcsFeature
    {
        public override void AddFixedUpdateSystems(IEcsSystems systems) =>
            systems
                .Add(new MovementSystem());

        public override void AddUpdateSystems(IEcsSystems systems) =>
            systems
                .Add(new UpdateMovementVelocitySystem())
                .Add(new DirectionCalculationSystem())
                .Add(new FlipSystem());
    }
}