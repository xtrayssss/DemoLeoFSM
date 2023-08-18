using MVP.Base.Presenter;

namespace MVP.Base.View
{
    public abstract class AbstractView<TPresenter> : BaseView where TPresenter : IIBasePresenter 
    {
        protected TPresenter Presenter;
    }
}