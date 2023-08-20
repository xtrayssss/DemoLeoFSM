using Components;
using Components.Requests.Self;
using FSM;
using UnityComponents.Configs;
using UnityComponents.Presenters;
using UnityComponents.Views;

namespace UnityComponents.States
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