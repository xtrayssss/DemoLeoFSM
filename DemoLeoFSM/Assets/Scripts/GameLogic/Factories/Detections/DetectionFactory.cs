using Common;
using GameLogic.Components.Attack;
using GameLogic.Components.Cooldowns;
using GameLogic.Components.Owners;
using GameLogic.Components.Requests.Self;
using GameLogic.Configs.Detection;
using Helpers.ConverterToEntity;
using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

namespace GameLogic.Factories.Detections
{
    internal class DetectionFactory : IDetectionFactory
    {
        private readonly IInstantiator _instantiator;

        public DetectionFactory(IInstantiator instantiator) =>
            _instantiator = instantiator;

        public void CreateGroundCheckPoint(IEcsSystems system, int ownerEntity, Transform parent,
            DetectionConfig detectionConfig)
        {
            InitializeWorlds(system, out EcsWorld defaultWorld);

            GameObject point = InstantiatePoint(parent, detectionConfig);

            int entity = GetConvertedEntity(point);

            InitializeComponents(defaultWorld, ownerEntity, detectionConfig, entity);
        }

        private void InitializeComponents(EcsWorld defaultWorld, int ownerEntity, DetectionConfig detectionConfig,
            int entity)
        {
            defaultWorld.GetPool<OwnerComponent>().Get(entity).Value = defaultWorld.PackEntityWithWorld(ownerEntity);
            defaultWorld.GetPool<Range>().Get(entity).value = detectionConfig.Radius;
            defaultWorld.GetPool<OwnerComponent>().Get(entity).Value = defaultWorld.PackEntityWithWorld(ownerEntity);
            defaultWorld.GetPool<HitLayer>().Get(entity).value = detectionConfig.Mask;
            defaultWorld.GetPool<CooldownBlockOverlap>().Get(entity).value = detectionConfig.CoolDownDetection;
        }

        private int GetConvertedEntity(GameObject point) =>
            point.GetComponentInChildren<ConverterToEntity>().Convert();

        private void InitializeWorlds(IEcsSystems system, out EcsWorld defaultWorld) =>
            defaultWorld = system.GetWorld();

        private GameObject InstantiatePoint(Transform parent, DetectionConfig detectionConfig) =>
            _instantiator.InstantiatePrefab(detectionConfig.StartPointPrefab, parent);
    }
}