using System;
using FSM;
using Infrastructure.Services.Timer;
using MVP.Sword;
using UnityComponents.Configs;
using UnityComponents.Views;

namespace UnityComponents.States.Sword
{
    internal class SwordAttackState : StateWithAnimation<SwordView>
    {
        private readonly IObservableTimerService _observableTimerService;
        private IDisposable _timer;

        public SwordAttackState(EntityView entityView, AnimationData animationData, SwordView view,
            IObservableTimerService observableTimerService)
            : base(entityView, animationData, view)
        {
            _observableTimerService = observableTimerService;
        }

        protected override void Setup()
        {
            base.Setup();

            _timer = _observableTimerService.StartTimer(AnimationData.DurationAnimation, () =>
            {
                _observableTimerService.StopTimer(_timer);
                IsAnimationComplete = true;
            });
        }
    }
}