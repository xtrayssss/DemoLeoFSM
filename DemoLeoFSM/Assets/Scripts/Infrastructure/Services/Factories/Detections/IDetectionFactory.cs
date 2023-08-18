using Leopotam.EcsLite.Packages.ECS.src;
using UnityComponents.Configs.Detection;
using UnityEngine;

namespace Infrastructure.Services.Factories.Detections
{
    internal interface IDetectionFactory
    {
        public void CreateGroundCheckPoint(EcsWorld defaultWorld, int ownerEntity, Transform parent,
            DetectionConfig detectionConfig);
    }
}