using Components.Grounds;
using Components.Performs;
using FSM;
using Infrastructure.Services.Factories.Requests.Velocity;
using Infrastructure.Services.Input;
using UnityComponents.Configs;
using UnityComponents.Views;
using UnityEngine;
using HeroView = MVP.Hero.HeroView;

namespace UnityComponents.States.Hero
{
    public class HeroMoveState : StateWithAnimation<HeroView>
    {
        private readonly IInputService _inputService;
        private readonly IVelocityRequestsFactory _velocityRequestsFactory;
        private readonly float _coyoteTime;
        private readonly IWorldService _worldService;
        public ControllableTimer CoyoteTimer { get; private set; }

        public HeroMoveState(EntityView entityView,
            AnimationData animationData,
            HeroView view, IInputService inputService, IVelocityRequestsFactory velocityRequestsFactory,
            float coyoteTime, IWorldService worldService) : base(
            entityView, animationData, view)
        {
            _inputService = inputService;
            _velocityRequestsFactory = velocityRequestsFactory;
            _coyoteTime = coyoteTime;
            _worldService = worldService;
        }

        protected override void Setup()
        {
            base.Setup();

            World.GetPool<PerformMovement>().Add(Entity);
            CoyoteTimer ??= new ControllableTimer(_coyoteTime);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            HandleCoyoteTimer();
        }

        protected override void Cleanup()
        {
            base.Cleanup();

            World.GetPool<PerformMovement>().Del(Entity);
            _velocityRequestsFactory.CreateUpdateMovementVelocityRequest(_worldService.EventsWorld, World, 0.0f, Entity);
            CoyoteTimer.SetTime(_coyoteTime);
            View.StopDustEffect();
        }

        private void HandleCoyoteTimer()
        {
            if (!IsMove())
                CoyoteTimer.Tick();
            else
                CoyoteTimer.SetTime(_coyoteTime);
        }
        
        private bool IsMove() =>
            _inputService.MovementDirection != Vector2.zero;
    }
}