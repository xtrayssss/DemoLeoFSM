using MVP.Base.Model;
using MVP.Base.View;
using UnityEngine;

namespace MVP.Base.Presenter
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