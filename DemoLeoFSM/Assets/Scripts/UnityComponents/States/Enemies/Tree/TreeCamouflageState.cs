using FSM;
using UnityComponents.Configs;
using UnityComponents.Presenters;
using UnityComponents.Views;

namespace UnityComponents.States.Enemies.Tree
{
    internal class TreeCamouflageState : StateWithAnimation<EnemyTreeView>
    {
        public TreeCamouflageState(EntityView entityView, AnimationData animationData, EnemyTreeView view) : base(
            entityView, animationData, view)
        {
        }
    }
}