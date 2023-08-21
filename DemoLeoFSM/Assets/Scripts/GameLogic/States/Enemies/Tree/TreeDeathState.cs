using GameLogic.Components;
using GameLogic.Components.Requests.Self;
using GameLogic.Configs;
using GameLogic.EntityViews;
using GameLogic.Skeletons.SkeletonFSM;
using GameLogic.UnityComponents.Views;

namespace GameLogic.States.Enemies.Tree
{
    internal class TreeDeathState : StateWithAnimation<EnemyTreeView>
    {
        public TreeDeathState(EntityView entityView, AnimationData animationData, EnemyTreeView view) : base(
            entityView, animationData, view)
        {
        }

        protected override void Setup()
        {
            base.Setup();

            World.GetPool<DestroyGameObjectSelfRequest>().Add(Entity);
            World.GetPool<DestroyEntitySelfRequest>().Add(Entity);
        }
    }
}