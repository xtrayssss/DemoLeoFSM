using Leopotam.EcsLite;

namespace Components.Requests.Other
{
    internal struct UpdateMovementVelocityRequest
    {
        public float Value;
        public EcsPackedEntityWithWorld TargetEntity;
    }
}