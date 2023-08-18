using MVP.Base.View;

namespace MVP.Base.Model
{
    public class AbstractModel<TView> : BaseModel where TView : BaseView
    {
        protected readonly TView View;

        public AbstractModel(TView view) => 
            View = view;
    }
}