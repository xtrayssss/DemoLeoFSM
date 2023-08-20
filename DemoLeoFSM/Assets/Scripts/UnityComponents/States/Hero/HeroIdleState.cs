using FSM;
using UnityComponents.Configs;
using UnityComponents.Views;
using HeroView = MVP.Hero.HeroView;

namespace UnityComponents.States.Hero
{
    public class HeroIdleState : StateWithAnimation<HeroView>
    {
        public HeroIdleState(EntityView entityView, AnimationData animationData,
            HeroView view) : base(entityView, animationData, view)
        {
        }
    }
}