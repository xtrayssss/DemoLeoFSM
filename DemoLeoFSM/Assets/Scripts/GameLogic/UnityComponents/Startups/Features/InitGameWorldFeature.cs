using GameLogic.Factories.Enemies;
using GameLogic.Factories.Hero;
using GameLogic.Services.Data;
using GameLogic.Systems.Inits;
using GameLogic.UnityComponents.ObjectContainers;
using Helpers.AffenCode.LeoECS_Lite_Zoo.Scripts.FeatureBased;
using Leopotam.EcsLite;

namespace GameLogic.UnityComponents.Startups.Features
{
    public class InitGameWorldFeature : BaseEcsFeature
    {
        private readonly IHeroFactory _heroFactory;
        private readonly IStaticDataService _staticDataService;
        private readonly SceneObjectContainer _sceneObjectContainer;
        private readonly IEnemyFactory _enemyFactory;

        public InitGameWorldFeature(IHeroFactory heroFactory, IStaticDataService staticDataService,
            SceneObjectContainer sceneObjectContainer, IEnemyFactory enemyFactory)
        {
            _heroFactory = heroFactory;
            _staticDataService = staticDataService;
            _sceneObjectContainer = sceneObjectContainer;
            _enemyFactory = enemyFactory;
        }

        public override void AddInitSystems(IEcsSystems systems) =>
            systems
                .Add(new InitLevelSystem(_heroFactory, _staticDataService, _enemyFactory, _sceneObjectContainer));
    }
}