using System;
using GameLogic.Configs;
using GameLogic.EntityViews;
using GameLogic.Skeletons.SkeletonFSM;
using GameLogic.UnityComponents.Views;
using Infrastructure.Services.Timer;

namespace GameLogic.States.Enemies.Tree
{
    internal class TreeAttackState : StateWithAnimation<EnemyTreeView>
    {
        private readonly IObservableTimerService _observableTimerService;
        private IDisposable _timer;

        public TreeAttackState(EntityView entityView, AnimationData animationData, EnemyTreeView view,
            IObservableTimerService observableTimerService) : base(
            entityView, animationData, view)
        {
            _observableTimerService = observableTimerService;
        }

        protected override void Setup()
        {
            base.Setup();

            _timer = _observableTimerService.StartTimer(AnimationData.DurationAnimation, () =>
            {
                IsAnimationComplete = true;
                _observableTimerService.StopTimer(_timer);
            });
        }
    }
}