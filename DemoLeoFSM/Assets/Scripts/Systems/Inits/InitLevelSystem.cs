using Infrastructure.Services.Data;
using Infrastructure.Services.Factories.Enemies;
using Infrastructure.Services.Factories.Hero;
using Leopotam.EcsLite.Packages.ECS.src;
using UnityComponents.Configs.Enemies;
using UnityComponents.Configs.Levels;
using UnityComponents.ObjectContainers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Systems.Inits
{
    internal class InitLevelSystem : IEcsPreInitSystem
    {
        private readonly IHeroFactory _heroFactory;
        private readonly IStaticDataService _staticDataService;
        private readonly IEnemyFactory _enemyFactory;
        private readonly SceneObjectContainer _sceneObjectContainer;

        public InitLevelSystem(IHeroFactory heroFactory, IStaticDataService staticDataService,
            IEnemyFactory enemyFactory, SceneObjectContainer sceneObjectContainer)
        {
            _heroFactory = heroFactory;
            _staticDataService = staticDataService;
            _enemyFactory = enemyFactory;
            _sceneObjectContainer = sceneObjectContainer;
        }

        public void PreInit(IEcsSystems systems)
        {
            _staticDataService.LoadWeaponsData();
            _staticDataService.LoadEnemiesData();
            _staticDataService.LoadLevelData();

            Transform hero = _heroFactory.CreateHero(systems).transform;

            CreateEnemies(_staticDataService.GetLevelData(GetSceneKey()), systems, hero);
        }

        private void CreateEnemies(LevelConfig levelData, IEcsSystems systems, Transform hero)
        {
            foreach (EnemySpawnerData enemySpawnerData in levelData.enemiesSpawnersData)
                _enemyFactory.CreateEnemy(systems, enemySpawnerData.EnemyTypeId, enemySpawnerData.Position,
                    _sceneObjectContainer.SubObjectContainersMap[ObjectContainerTypeId.Enemy], hero);
        }

        private string GetSceneKey() =>
            SceneManager.GetActiveScene().name;
    }
}