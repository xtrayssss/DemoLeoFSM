using Leopotam.EcsLite;

namespace Components.Requests.Other
{
    public struct UpdateJumpVelocityRequest
    {
        public float Value;
        public EcsPackedEntityWithWorld TargetEntity;
    }
}