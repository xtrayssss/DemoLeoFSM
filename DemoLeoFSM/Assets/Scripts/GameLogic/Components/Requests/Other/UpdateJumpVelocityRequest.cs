using Leopotam.EcsLite;

namespace GameLogic.Components.Requests.Other
{
    public struct UpdateJumpVelocityRequest
    {
        public float Value;
        public EcsPackedEntityWithWorld TargetEntity;
    }
}