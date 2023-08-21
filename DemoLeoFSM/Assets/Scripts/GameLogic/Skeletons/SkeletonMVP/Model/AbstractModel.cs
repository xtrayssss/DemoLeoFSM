using GameLogic.Skeletons.SkeletonMVP.View;

namespace GameLogic.Skeletons.SkeletonMVP.Model
{
    public class AbstractModel<TView> : BaseModel where TView : BaseView
    {
        protected readonly TView View;

        public AbstractModel(TView view) => 
            View = view;
    }
}