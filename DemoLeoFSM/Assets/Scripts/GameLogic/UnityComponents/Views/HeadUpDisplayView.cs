using GameLogic.Skeletons.SkeletonMVP.View;
using GameLogic.UnityComponents.Presenters;
using UnityEngine;
using UnityEngine.UI;

namespace GameLogic.UnityComponents.Views
{
    public class HeadUpDisplayView : AbstractViewWithMonobehPresenter<HeadUpDisplayPresenter>
    {
        [SerializeField] private Image hpFill;
        [SerializeField] private float smoothTime;

        private float _velocity;

        public void HealBarRender(float targetValue, float maxValue) =>
            hpFill.fillAmount = Mathf.SmoothDamp(hpFill.fillAmount, targetValue / maxValue, ref _velocity, smoothTime);
    }
}