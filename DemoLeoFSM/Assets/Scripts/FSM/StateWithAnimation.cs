﻿using MVP.Base.View;
using UnityComponents.Configs;
using UnityComponents.Views;

namespace FSM
{
    public class StateWithAnimation<TView> : State where TView : BaseAnimationView
    {
        protected readonly AnimationData AnimationData;
        public bool IsAnimationComplete { get; protected set; }

        protected readonly TView View;

        protected StateWithAnimation(EntityView entityView, AnimationData animationData, TView view) : base(entityView)
        {
            AnimationData = animationData;
            View = view;
        }

        public override void Enter()
        {
            base.Enter();

            View.PlayAnimation(AnimationData.HashAnimation);
        }

        protected override void Cleanup()
        {
            base.Cleanup();

            IsAnimationComplete = false;
        }
    }
}