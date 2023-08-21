using Leopotam.EcsLite;

namespace GameLogic.Components.Requests.Other
{
    internal struct UpdateMovementVelocityRequest
    {
        public float Value;
        public EcsPackedEntityWithWorld TargetEntity;
    }
}