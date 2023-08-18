using MVP.Base.Presenter;
using UnityEngine;

namespace MVP.Base.View
{
    public abstract class AbstractViewWithMonobehPresenter<TPresenter> : BaseView
        where TPresenter : BaseMonobehaviourPresenter
    {
        [SerializeField] protected TPresenter presenter;
    }
}