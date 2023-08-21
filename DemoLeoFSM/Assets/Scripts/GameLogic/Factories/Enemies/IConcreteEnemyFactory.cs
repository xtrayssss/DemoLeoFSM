using GameLogic.Configs.Enemies;
using Leopotam.EcsLite;
using UnityEngine;

namespace GameLogic.Factories.Enemies
{
    internal interface IConcreteEnemyFactory
    {
        public EnemyTypeId EnemyTypeId { get; }
        public GameObject CreateEnemy(IEcsSystems systems, Vector2 spawnPosition, Transform parent, Transform destination);
    }
}