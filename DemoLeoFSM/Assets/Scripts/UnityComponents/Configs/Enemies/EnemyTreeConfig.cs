using UnityEngine;

namespace UnityComponents.Configs.Enemies
{
    [CreateAssetMenu(fileName = "TreeData", menuName = "Data/Enemies/Tree/Tree")]
    public class EnemyTreeConfig : EnemyConfig
    {
        [Header("View")] [SerializeField] private EnemyTreeViewConfig enemyTreeViewConfig;

        #region Properties

        public EnemyTreeViewConfig EnemyTreeViewConfig => enemyTreeViewConfig;

        #endregion
    }
}