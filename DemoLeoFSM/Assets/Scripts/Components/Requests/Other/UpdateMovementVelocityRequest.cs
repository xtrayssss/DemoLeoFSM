using Leopotam.EcsLite.Packages.ECS.src;

namespace Components.Requests.Other
{
    internal struct UpdateMovementVelocityRequest
    {
        public float Value;
        public EcsPackedEntityWithWorld TargetEntity;
    }
}