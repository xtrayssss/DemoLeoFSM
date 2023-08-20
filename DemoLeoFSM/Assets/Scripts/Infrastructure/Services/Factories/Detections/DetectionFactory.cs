using Components.Attack;
using Components.CoolDowns;
using Components.Owners;
using Leopotam.EcsLite.Packages.ECS.src;
using Packages.ECS.src;
using UnityComponents.Configs.Detection;
using UnityEngine;

namespace Infrastructure.Services.Factories.Detections
{
    internal class DetectionFactory : IDetectionFactory
    {
        public void CreateGroundCheckPoint(EcsWorld defaultWorld, int ownerEntity, Transform parent,
            DetectionConfig detectionConfig)
        {
            EcsConverter.InstantiateAndCreateEntity(detectionConfig.StartPointPrefab, parent, defaultWorld, out int entity);

            defaultWorld.GetPool<OwnerComponent>().Get(entity).Value = defaultWorld.PackEntityWithWorld(ownerEntity);
            defaultWorld.GetPool<Range>().Get(entity).value = detectionConfig.Radius;
            defaultWorld.GetPool<OwnerComponent>().Get(entity).Value = defaultWorld.PackEntityWithWorld(ownerEntity);
            defaultWorld.GetPool<HitLayer>().Get(entity).value = detectionConfig.Mask;
            defaultWorld.GetPool<CooldownBlockOverlap>().Get(entity).value = detectionConfig.CoolDownDetection;
        }
    }
}