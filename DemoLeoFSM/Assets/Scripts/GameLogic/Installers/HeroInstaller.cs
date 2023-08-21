using GameLogic.EntityViews;
using GameLogic.Factories.Hero;
using UnityEngine;
using Zenject;

namespace GameLogic.Installers
{
    public class HeroInstaller : MonoInstaller
    {
        [SerializeField] private HeroEntityView heroEntityViewPrefab;
        [SerializeField] private Transform parent;
        
        private HeroEntityView _heroEntityView;

        public override void InstallBindings()
        {
            BindHeroView();
            BindHeroFactory();
        }

        private void BindHeroView()
        {
            _heroEntityView = Container.InstantiatePrefabForComponent<HeroEntityView>(heroEntityViewPrefab, parent);

            Container.Bind<HeroEntityView>().FromInstance(_heroEntityView).AsSingle();
        }

        private void BindHeroFactory() =>
            Container.Bind<IHeroFactory>().To<HeroFactory>().AsSingle();
    }
}