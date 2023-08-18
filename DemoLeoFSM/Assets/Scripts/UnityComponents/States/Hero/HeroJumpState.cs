using Components.EngineComponents;
using Components.Grounds;
using Components.Jump;
using Components.Performs;
using FSM;
using Infrastructure.Services.Factories.Requests.Velocity;
using UnityComponents.Configs;
using UnityComponents.Views;
using UnityEngine;
using HeroView = MVP.Hero.HeroView;

namespace UnityComponents.States.Hero
{
    public class HeroJumpState : StateWithAnimation<HeroView>
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