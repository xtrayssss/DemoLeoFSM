using MVP.Base.Presenter;
using UnityEngine;

namespace MVP.Base.View
{
    public abstract class AbstractAnimationViewWithMonobehPresenter<TPresenter> : BaseAnimationView
        where TPresenter : BaseMonobehaviourPresenter
    {
        [SerializeField] protected TPresenter presenter;
    }
}