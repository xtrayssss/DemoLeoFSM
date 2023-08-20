using Leopotam.EcsLite;
using UnityComponents.Configs.Enemies;
using UnityEngine;

namespace Infrastructure.Services.Factories.Enemies
{
    internal interface IConcreteEnemyFactory
    {
        public EnemyTypeId EnemyTypeId { get; }
        public GameObject CreateEnemy(IEcsSystems systems, Vector2 spawnPosition, Transform parent, Transform destination);
    }
}