using System.Linq;
using GameLogic.Configs.Enemies;
using GameLogic.Configs.Levels;
using GameLogic.UnityComponents;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Editor
{
    [CustomEditor(typeof(LevelConfig))]
    public class LevelEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            LevelConfig levelConfiguration = (LevelConfig) target;

            if (GUILayout.Button("Collect"))
            {
                levelConfiguration.enemiesSpawnersData =
                    FindObjectsOfType<EnemySpawnPoint>()
                        .Select(x => new EnemySpawnerData(x.EnemyTypeId, x.transform.position)).ToArray();

                levelConfiguration.sceneName = SceneManager.GetActiveScene().name;
            }

            EditorUtility.SetDirty(target);
        }
    }
}