using FSM;
using MVP.Sword;
using UnityComponents.Configs;
using UnityComponents.Views;

namespace UnityComponents.States.Sword
{
    internal class SwordEmptyState : StateWithAnimation<SwordView>
    {
        public SwordEmptyState(EntityView entityView, AnimationData animationData, SwordView view)
            : base(entityView, animationData, view)
        {
        }
    }
}