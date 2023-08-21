using Leopotam.EcsLite;

namespace GameLogic.Factories.Requests.Velocity
{
    public interface IVelocityRequestsFactory
    {
        public void CreateUpdateMovementVelocityRequest(EcsWorld eventsWorld, EcsWorld defaultWorld, float value,
            int entity);

        public void CreateUpdateJumpVelocityRequest(EcsWorld eventsWorld, EcsWorld defaultWorld, float value,
            int entity);
    }
}