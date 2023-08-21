using System;
using UnityEngine;

namespace GameLogic.Configs.Enemies
{
    [Serializable]
    public class EnemySpawnerData
    {
        [field: SerializeField] public EnemyTypeId EnemyTypeId { get; private set; }
        [field: SerializeField] public Vector3 Position { get; private set; }

        public EnemySpawnerData(EnemyTypeId enemyTypeId, Vector3 position)
        {
            EnemyTypeId = enemyTypeId;
            Position = position;
        }
    }
}