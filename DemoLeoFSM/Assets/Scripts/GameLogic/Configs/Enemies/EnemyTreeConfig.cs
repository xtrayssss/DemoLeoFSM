using NaughtyAttributes;
using UnityEngine;

namespace GameLogic.Configs.Enemies
{
    [CreateAssetMenu(fileName = "TreeData", menuName = "Data/Enemies/Tree/Tree")]
    public class EnemyTreeConfig : EnemyConfig
    {
        [BoxGroup("View")] [SerializeField] [Expandable] [Required]
        private EnemyTreeViewConfig enemyTreeViewConfig;

        #region Other

        public EnemyTreeViewConfig EnemyTreeViewConfig => enemyTreeViewConfig;

        #endregion
    }
}