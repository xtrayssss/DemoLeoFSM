using Leopotam.EcsLite;
using Leopotam.EcsLite.Packages.ECS.src;

namespace Components.Requests.Other
{
    public struct UpdateJumpVelocityRequest
    {
        public float Value;
        public EcsPackedEntityWithWorld TargetEntity;
    }
}