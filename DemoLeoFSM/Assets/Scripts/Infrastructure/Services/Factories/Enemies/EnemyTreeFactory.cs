using Common;
using Components.Damage;
using Components.Health;
using Components.Movement;
using Infrastructure.Services.Data;
using Leopotam.EcsLite;
using UnityComponents.Configs.Enemies;
using UnityComponents.Views;
using UnityEngine;
using Zenject;

namespace Infrastructure.Services.Factories.Enemies
{
    internal class EnemyTreeFactory : IEnemyTreeFactory
    {
        public EnemyTypeId EnemyTypeId { get; } = EnemyTypeId.Tree;

        private readonly IInstantiator _instantiator;
        private readonly IStaticDataService _staticDataService;
        
        private EcsWorld _defaultWorld;

        public EnemyTreeFactory(IInstantiator instantiator, IStaticDataService staticDataService)
        {
            _instantiator = instantiator;
            _staticDataService = staticDataService;
        }

        public GameObject CreateEnemy(IEcsSystems systems, Vector2 spawnPosition, Transform parent, Transform destination)
        {
            // _defaultWorld = systems.GetWorld();
            // systems.GetWorld(WorldsNames.EventsWorldName);
            //
            // EnemyTreeConfig enemyTreeConfig = _staticDataService.GetEnemyData<EnemyTreeConfig>(EnemyTypeId);
            //
            // // GameObject treeGO = EcsConverterWithZenject.InstantiateAndCreateEntity(enemyTreeConfig.EnemyPrefab,
            // //     _defaultWorld, parent, spawnPosition,
            // //     _instantiator, out int entity);
            //
            // _defaultWorld.GetPool<Destination>().Get(entity).value = destination;
            // _defaultWorld.GetPool<Health>().Get(entity).value = enemyTreeConfig.Health;
            // _defaultWorld.GetPool<MovementSpeed>().Get(entity).value = enemyTreeConfig.MovementSpeed;
            // _defaultWorld.GetPool<Damage>().Get(entity).value = enemyTreeConfig.Damage;
            //
            // treeGO.GetComponent<EnemyEntityView>().Init(entity, _defaultWorld);
            //
            // return treeGO;
            return null;
        }
    }
}