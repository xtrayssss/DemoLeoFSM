using System.Collections.Generic;
using System.Linq;
using Common;
using GameLogic.Configs.Enemies;
using GameLogic.Configs.Hero;
using GameLogic.Configs.Levels;
using GameLogic.Configs.Weapons;
using Infrastructure.Services.Asset;

namespace GameLogic.Services.Data
{
    internal class StaticDataService : IStaticDataService
    {
        private readonly IAssetProvider _assetProvider;

        private Dictionary<WeaponTypeId, WeaponConfig> _weapons;
        private Dictionary<EnemyTypeId, EnemyConfig> _enemies;
        private Dictionary<string, LevelConfig> _levels;

        public StaticDataService(IAssetProvider assetProvider) =>
            _assetProvider = assetProvider;

        public HeroConfig GetHeroData() =>
            _assetProvider.Load<HeroConfig>(AssetPaths.HeroDataPath);

        public TConfig GetWeaponData<TConfig>(WeaponTypeId weaponTypeId) where TConfig : WeaponConfig =>
            (TConfig) _weapons[weaponTypeId];

        public TConfig GetEnemyData<TConfig>(EnemyTypeId enemyTypeId) where TConfig : EnemyConfig => 
            (TConfig) _enemies[enemyTypeId];

        public LevelConfig GetLevelData(string sceneKey) =>
            _levels[sceneKey];

        public void LoadLevelData() =>
            _levels = _assetProvider.LoadAll<LevelConfig>(AssetPaths.LevelsPath).ToDictionary(x => x.sceneName);

        public void LoadEnemiesData()
        {
            EnemyConfig[] enemyConfigs = _assetProvider.LoadAll<EnemyConfig>(AssetPaths.EnemiesConfigsPath);
            _enemies = enemyConfigs.ToDictionary(x => x.EnemyTypeId);
        }

        public void LoadWeaponsData() =>
            _weapons = _assetProvider.LoadAll<WeaponConfig>(AssetPaths.WeaponPath)
                .ToDictionary(config => config.WeaponTypeId);
    }
}