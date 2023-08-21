using GameLogic.Configs.Enemies;
using UnityEngine;

namespace GameLogic.Configs.Levels
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Data/Level")]
    public class LevelConfig : ScriptableObject
    {
        public EnemySpawnerData[] enemiesSpawnersData;
        public string sceneName;
    }
}