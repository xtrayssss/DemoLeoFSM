using GameLogic.Configs;
using GameLogic.EntityViews;
using GameLogic.Skeletons.SkeletonFSM;
using GameLogic.UnityComponents.Views;

namespace GameLogic.States.Enemies.Tree
{
    internal class TreeIdleState : StateWithAnimation<EnemyTreeView>
    {
        public TreeIdleState(EntityView entityView, AnimationData animationData, EnemyTreeView view) : base(entityView,
            animationData, view)
        {
        }
    }
}