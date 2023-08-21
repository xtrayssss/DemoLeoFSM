using GameLogic.Configs;
using GameLogic.EntityViews;
using GameLogic.Skeletons.SkeletonFSM;
using HeroView = GameLogic.UnityComponents.Views.HeroView;

namespace GameLogic.States.Hero
{
    public class HeroIdleState : StateWithAnimation<UnityComponents.Views.HeroView>
    {
        public HeroIdleState(EntityView entityView, AnimationData animationData,
            HeroView view) : base(entityView, animationData, view)
        {
        }
    }
}