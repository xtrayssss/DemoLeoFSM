using GameLogic.Skeletons.SkeletonMVP.Model;
using GameLogic.Skeletons.SkeletonMVP.View;
using UnityEngine;

namespace GameLogic.Skeletons.SkeletonMVP.Presenter
{
    public class AbstractMonobehaviourPresenter<TView, TModel> : BaseMonobehaviourPresenter
        where TView : BaseView where TModel : BaseModel
    {
        [SerializeField] protected TView view;

        protected TModel Model;

        protected void Init(TModel model) => 
            Model = model;
    }
}