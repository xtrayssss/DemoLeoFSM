using UnityComponents.Configs.Enemies;
using UnityComponents.Configs.Hero;
using UnityComponents.Configs.Levels;
using UnityComponents.Configs.Weapons;

namespace Infrastructure.Services.Data
{
    internal interface IStaticDataService
    {
        public HeroConfig GetHeroData();
        public TConfig GetWeaponData<TConfig>(WeaponTypeId weaponTypeId) where TConfig : WeaponConfig;
        public void LoadWeaponsData();
        public TConfig GetEnemyData<TConfig>(EnemyTypeId enemyTypeId) where TConfig : EnemyConfig;
        public void LoadEnemiesData();
        public LevelConfig GetLevelData(string sceneKey);
        public void LoadLevelData();
    }
}