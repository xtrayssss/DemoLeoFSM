using GameLogic.Models;
using GameLogic.Skeletons.SkeletonMVP.Presenter;
using GameLogic.UnityComponents.Views;

namespace GameLogic.UnityComponents.Presenters
{
    public class HeadUpDisplayPresenter : AbstractMonobehaviourPresenter<HeadUpDisplayView, HeadUpDisplayModel>
    {
        public void NotifyHPBar()
        {
            //View.HealBarRender();
        }
    }
}