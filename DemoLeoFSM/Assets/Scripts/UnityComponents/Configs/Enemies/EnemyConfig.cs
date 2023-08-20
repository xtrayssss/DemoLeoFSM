using UnityEngine;

namespace UnityComponents.Configs.Enemies
{
    public class EnemyConfig : ScriptableObject
    {
        [Header("General")]
        [SerializeField] private EnemyTypeId enemyTypeId;
        [SerializeField] private GameObject enemyPrefab;

        [Header("Stats")]
        [SerializeField, Range(1, 300)] private float movementSpeed = 50;
        [SerializeField, Range(1, 100)] private float health = 50;
        [SerializeField, Range(1, 100)] private float damage = 50;

        #region Properties

        public float Damage => damage;
        public GameObject EnemyPrefab => enemyPrefab;
        public EnemyTypeId EnemyTypeId => enemyTypeId;
        public float MovementSpeed => movementSpeed;
        public float Health => health;

        #endregion
    }
}