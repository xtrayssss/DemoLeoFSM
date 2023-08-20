using Leopotam.EcsLite;
using UnityComponents.Configs.Enemies;
using UnityEngine;

namespace Infrastructure.Services.Factories.Enemies
{
    internal interface IEnemyFactory
    {
        public GameObject CreateEnemy(IEcsSystems world, EnemyTypeId enemyTypeId, Vector2 spawnPosition,
            Transform parent,
            Transform hero);
    }
}