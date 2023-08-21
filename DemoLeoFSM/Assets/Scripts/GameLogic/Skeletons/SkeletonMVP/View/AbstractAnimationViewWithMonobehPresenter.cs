using GameLogic.Skeletons.SkeletonMVP.Presenter;
using UnityEngine;

namespace GameLogic.Skeletons.SkeletonMVP.View
{
    public abstract class AbstractAnimationViewWithMonobehPresenter<TPresenter> : BaseAnimationView
        where TPresenter : BaseMonobehaviourPresenter
    {
        [SerializeField] protected TPresenter presenter;
    }
}