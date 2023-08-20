using UnityEngine;

namespace MVP.Base.View
{
    public abstract class BaseAnimationView : BaseView
    {
        [SerializeField] protected Animator animator;
        [SerializeField] protected SpriteRenderer sprite;

        public virtual void PlayAnimation(string animationName) =>
            animator.Play(animationName);

        public virtual void PlayAnimation(int animationHash) =>
            animator.Play(animationHash);
    }
}