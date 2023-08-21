using NaughtyAttributes;
using UnityEngine;

namespace GameLogic.Configs.Enemies
{
    public class EnemyConfig : ScriptableObject
    {
        [BoxGroup("General")] [SerializeField] [Required]
        private GameObject enemyPrefab;

        [BoxGroup("General")] [SerializeField] private EnemyTypeId enemyTypeId;

        [BoxGroup("Stats")] [SerializeField, Range(1, 300)]
        private float movementSpeed = 50;

        [BoxGroup("Stats")] [SerializeField] [Range(1, 100)] [OnValueChanged(nameof(UpdateValueHealthBar))]
        private float health = 50;

        [BoxGroup("Stats")] [SerializeField] [ProgressBar("Health", 100, EColor.Green)]
        private float healthBar;

        [BoxGroup("Stats")] [SerializeField, Range(1, 100)] [OnValueChanged(nameof(UpdateValueDamageBar))]
        private float damage = 50;

        [BoxGroup("Stats")] [SerializeField] [ProgressBar("Damage", 100, EColor.Gray)]
        private float damageBar;

        #region Other

        public void UpdateValueHealthBar() =>
            healthBar = health;

        public void UpdateValueDamageBar() =>
            damageBar = damage;

        public float Damage => damage;
        public GameObject EnemyPrefab => enemyPrefab;
        public EnemyTypeId EnemyTypeId => enemyTypeId;
        public float MovementSpeed => movementSpeed;
        public float Health => health;

        #endregion
    }
}