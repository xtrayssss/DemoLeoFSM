using System;
using GameLogic.Configs;
using GameLogic.EntityViews;
using GameLogic.Skeletons.SkeletonFSM;
using Infrastructure.Services.Timer;
using HeroView = GameLogic.UnityComponents.Views.HeroView;

namespace GameLogic.States.Hero
{
    public class HeroLandState : StateWithAnimation<UnityComponents.Views.HeroView>
    {

        private readonly IObservableTimerService _observableTimerService;
        private IDisposable _timer;

        public HeroLandState(EntityView entityView,
            AnimationData animationData,
            HeroView view, IObservableTimerService observableTimerService) : base(
            entityView,
            animationData, view)
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
        
        protected override void Cleanup()
        {
            base.Cleanup();
            
            _observableTimerService.StopTimer(_timer);
        }
    }
}