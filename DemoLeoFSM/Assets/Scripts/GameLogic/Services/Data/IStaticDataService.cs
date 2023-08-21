using GameLogic.Configs.Enemies;
using GameLogic.Configs.Hero;
using GameLogic.Configs.Levels;
using GameLogic.Configs.Weapons;

namespace GameLogic.Services.Data
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