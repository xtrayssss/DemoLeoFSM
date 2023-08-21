using GameLogic.Skeletons.SkeletonMVP.Presenter;

namespace GameLogic.Skeletons.SkeletonMVP.View
{
    public abstract class AbstractView<TPresenter> : BaseView where TPresenter : IIBasePresenter 
    {
        protected TPresenter Presenter;
    }
}