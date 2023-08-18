using System;
using FSM;
using Infrastructure.Services.Timer;
using UnityComponents.Configs;
using UnityComponents.Presenters;
using UnityComponents.Views;
using UnityEngine;

namespace UnityComponents.States.Enemies.Tree
{
    internal class TreeIntroductionState : StateWithAnimation<EnemyTreeView>
    {
        private readonly IObservableTimerService _observableTimerService;
        private IDisposable _timer;

        public TreeIntroductionState(EntityView entityView, AnimationData animationData, EnemyTreeView view,
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