using GameLogic.Configs;
using GameLogic.EntityViews;
using GameLogic.Skeletons.SkeletonFSM;
using GameLogic.UnityComponents.Views;

namespace GameLogic.States.Sword
{
    internal class SwordEmptyState : StateWithAnimation<SwordView>
    {
        public SwordEmptyState(EntityView entityView, AnimationData animationData, SwordView view)
            : base(entityView, animationData, view)
        {
        }
    }
}