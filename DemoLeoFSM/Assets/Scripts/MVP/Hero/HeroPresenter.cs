using MVP.Base.Presenter;
using UnityComponents.Configs.Hero;
using UnityEngine;

namespace MVP.Hero
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