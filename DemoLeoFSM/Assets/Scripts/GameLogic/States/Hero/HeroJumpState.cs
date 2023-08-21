using GameLogic.Components.Jump;
using GameLogic.Components.Performs;
using GameLogic.Configs;
using GameLogic.EntityViews;
using GameLogic.Factories.Requests.Velocity;
using GameLogic.Skeletons.SkeletonFSM;
using GameLogic.UnityComponents.Hero;
using Infrastructure.Services;
using HeroView = GameLogic.UnityComponents.Views.HeroView;

namespace GameLogic.States.Hero
{
    public class HeroJumpState : StateWithAnimation<UnityComponents.Views.HeroView>
    {
        private readonly IVelocityRequestsFactory _velocityRequestsFactory;
        private readonly IWorldService _worldService;

        public HeroJumpState(EntityView entityView,
            AnimationData animationData,
            HeroView view, IVelocityRequestsFactory velocityRequestsFactory, IWorldService worldService) : base(entityView, animationData,
            view)
        {
            _velocityRequestsFactory = velocityRequestsFactory;
            _worldService = worldService;
        }

        protected override void Setup()
        {
            base.Setup();

            World.GetPool<PerformJump>().Add(Entity);
            World.GetPool<PerformMovement>().Add(Entity);
        }

        protected override void Cleanup()
        {
            base.Cleanup();

            World.GetPool<PerformMovement>().Del(Entity);
            World.GetPool<PerformJump>().Del(Entity);

            float jumpMaxVelocity = World.GetPool<JumpMaxVelocity>().Get(Entity).value;

            _velocityRequestsFactory.CreateUpdateJumpVelocityRequest(_worldService.EventsWorld, World, jumpMaxVelocity,
                Entity);

            _velocityRequestsFactory.CreateUpdateMovementVelocityRequest(_worldService.EventsWorld, World, 0.0f, Entity);
        }
    }
}