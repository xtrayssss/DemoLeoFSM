using Components.Requests.Other;
using Leopotam.EcsLite;

namespace Infrastructure.Services.Factories.Requests.Velocity
{
    internal class VelocityRequestsFactory : IVelocityRequestsFactory
    {
        public void CreateUpdateMovementVelocityRequest(EcsWorld eventsWorld, EcsWorld defaultWorld, float value,
            int entity)
        {
            int requestEntity = eventsWorld.NewEntity();
            ref var updateMovementVelocityRequest =
                ref eventsWorld.GetPool<UpdateMovementVelocityRequest>().Add(requestEntity);
            updateMovementVelocityRequest.Value = value;
            updateMovementVelocityRequest.TargetEntity = defaultWorld.PackEntityWithWorld(entity);
        }

        public void CreateUpdateJumpVelocityRequest(EcsWorld eventsWorld, EcsWorld defaultWorld, float value,
            int entity)
        {
            int requestEntity = eventsWorld.NewEntity();
            ref var updateJumpVelocityRequest = ref eventsWorld.GetPool<UpdateJumpVelocityRequest>().Add(requestEntity);
            updateJumpVelocityRequest.Value = value;
            updateJumpVelocityRequest.TargetEntity = defaultWorld.PackEntityWithWorld(entity);
        }
    }
}