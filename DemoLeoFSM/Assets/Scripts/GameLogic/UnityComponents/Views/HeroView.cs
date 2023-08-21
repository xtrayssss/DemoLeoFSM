using GameLogic.Skeletons.SkeletonMVP.View;
using GameLogic.UnityComponents.Presenters;
using UnityEngine;

namespace GameLogic.UnityComponents.Views
{
    public class HeroView : AbstractAnimationViewWithMonobehPresenter<HeroPresenter>
    {
        [SerializeField] private ParticleSystem dustEffect;
        
        public void PlayDustEffect()
        {
            //dustEffect.transform.parent.gameObject.SetActive(true);
            //dustEffect.Play();
        }

        public void StopDustEffect()
        {
            //dustEffect.transform.parent.gameObject.SetActive(false);
            //dustEffect.Stop();
        }

        public void UpdateDustEffectDirection(float movementDirectionX)
        {
           // dustEffect.transform.localScale = new Vector3(movementDirectionX > 0 ? 1 : -1, 1, 1);
        }
    }
}