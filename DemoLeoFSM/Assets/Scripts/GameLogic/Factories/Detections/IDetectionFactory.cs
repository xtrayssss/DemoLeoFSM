using GameLogic.Configs.Detection;
using Leopotam.EcsLite;
using UnityEngine;

namespace GameLogic.Factories.Detections
{
    internal interface IDetectionFactory
    {
        public void CreateGroundCheckPoint(IEcsSystems system, int ownerEntity, Transform parent,
            DetectionConfig detectionConfig);
    }
}