using GameLogic.Configs.Hero;
using GameLogic.Models;
using GameLogic.Skeletons.SkeletonMVP.Presenter;
using GameLogic.UnityComponents.Views;
using UnityEngine;

namespace GameLogic.UnityComponents.Presenters
{
    public class HeroPresenter : AbstractMonobehaviourPresenter<HeroView, HeroModel>
    {
        [SerializeField] private HeroConfig heroConfig;

        private void Start()
        {
            Init(new HeroModel(view, heroConfig));
        }
    }
}