using System;
using FSM;
using Infrastructure.Services.Timer;
using UnityComponents.Configs;
using UnityComponents.Views;
using UnityEngine;
using HeroView = MVP.Hero.HeroView;

namespace UnityComponents.States.Hero
{
    public class HeroJumpPreparationState : StateWithAnimation<HeroView>
    {
        private readonly IObservableTimerService _observableTimerService;
        private IDisposable _timer;

        public HeroJumpPreparationState(EntityView entityView,
            AnimationData animationData, HeroView view,
            IObservableTimerService observableTimerService) : base(entityView, animationData, view)
        {
            _observableTimerService = observableTimerService;
        }

        protected override void Setup()
        {
            base.Setup();

            _timer = _observableTimerService.StartTimer(AnimationData.DurationAnimation, () =>
            {
                IsAnimationComplete = true;
                Debug.Log("stop");
                _observableTimerService.StopTimer(_timer);
            });
        }

        protected override void Cleanup()
        {
            base.Cleanup();

            _observableTimerService.StopTimer(_timer);
        }
    }
}