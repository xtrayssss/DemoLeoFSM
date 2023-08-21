using GameLogic.Skeletons.SkeletonMVP.Presenter;
using UnityEngine;

namespace GameLogic.Skeletons.SkeletonMVP.View
{
    public abstract class AbstractViewWithMonobehPresenter<TPresenter> : BaseView
        where TPresenter : BaseMonobehaviourPresenter
    {
        [SerializeField] protected TPresenter presenter;
    }
}