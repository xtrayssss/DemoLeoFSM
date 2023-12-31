﻿using System.Collections.Generic;
using System.Linq;
using GameLogic.Configs.Enemies;
using Leopotam.EcsLite;
using UnityEngine;

namespace GameLogic.Factories.Enemies
{
    internal class EnemyFactory : IEnemyFactory
    {
        private readonly Dictionary<EnemyTypeId, IConcreteEnemyFactory> _factories;

        public EnemyFactory(IEnumerable<IConcreteEnemyFactory> concreteEnemyFactories) =>
            _factories = concreteEnemyFactories.ToDictionary(x => x.EnemyTypeId);

        public GameObject CreateEnemy(IEcsSystems systems, EnemyTypeId enemyTypeId, Vector2 spawnPosition,
            Transform parent,
            Transform hero) =>
            _factories.TryGetValue(enemyTypeId, out IConcreteEnemyFactory factory)
                ? factory.CreateEnemy(systems, spawnPosition, parent, hero)
                : null;
    }
}