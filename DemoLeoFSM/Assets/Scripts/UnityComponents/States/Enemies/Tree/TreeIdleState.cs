using FSM;
using UnityComponents.Configs;
using UnityComponents.Presenters;
using UnityComponents.Views;

namespace UnityComponents.States.Enemies.Tree
{
    internal class TreeIdleState : StateWithAnimation<EnemyTreeView>
    {
        public TreeIdleState(EntityView entityView, AnimationData animationData, EnemyTreeView view) : base(entityView,
            animationData, view)
        {
        }
    }
}