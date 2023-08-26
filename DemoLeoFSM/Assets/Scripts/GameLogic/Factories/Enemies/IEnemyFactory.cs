using GameLogic.Configs.Enemies;
using Leopotam.EcsLite;
using UnityEngine;

namespace GameLogic.Factories.Enemies
{
    public interface IEnemyFactory
    {
        public GameObject CreateEnemy(IEcsSystems world, EnemyTypeId enemyTypeId, Vector2 spawnPosition,
            Transform parent,
            Transform hero);
    }
}