using UnityComponents.Configs.Enemies;
using UnityEngine;

namespace UnityComponents.Configs.Levels
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Data/Level")]
    public class LevelConfig : ScriptableObject
    {
        public EnemySpawnerData[] enemiesSpawnersData;
        public string sceneName;
    }
}