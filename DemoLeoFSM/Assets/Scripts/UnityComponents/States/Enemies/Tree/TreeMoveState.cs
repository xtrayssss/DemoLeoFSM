using Components.Performs;
using FSM;
using Infrastructure.Services.Factories.Requests.Velocity;
using UnityComponents.Configs;
using UnityComponents.Presenters;
using UnityComponents.Views;

namespace UnityComponents.States.Enemies.Tree
{
    internal class TreeMoveState : StateWithAnimation<EnemyTreeView>
    {
        private readonly IWorldService _worldService;
        private readonly IVelocityRequestsFactory _velocityRequestsFactory;

        public TreeMoveState(EntityView entityView, AnimationData animationData, EnemyTreeView view,
            IWorldService worldService, IVelocityRequestsFactory velocityRequestsFactory) : base(
            entityView, animationData, view)
        {
            _worldService = worldService;
            _velocityRequestsFactory = velocityRequestsFactory;
        }

        protected override void Setup()
        {
            base.Setup();

            World.GetPool<PerformMovement>().Add(Entity);
        }

        protected override void Cleanup()
        {
            base.Cleanup();

            World.GetPool<PerformMovement>().Del(Entity);
            
            _velocityRequestsFactory.CreateUpdateMovementVelocityRequest(_worldService.EventsWorld, World, 0,
                Entity);
        }
    }
}