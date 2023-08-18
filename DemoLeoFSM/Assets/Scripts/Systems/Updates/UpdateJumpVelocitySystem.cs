using System.Threading.Tasks;
using Common;
using Components.Jump;
using Components.Requests.Other;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Packages.ECS.src;

namespace Systems.Updates
{
    internal class UpdateJumpVelocitySystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld _eventsWorld;
        private EcsWorld _defaultWorld;
        private EcsFilter _filter;
        private EcsPool<UpdateJumpVelocityRequest> _updateVelocityRequests;
        private EcsPool<JumpVelocity> _jumpVelocities;

        public void Init(IEcsSystems systems)
        {
            _defaultWorld = systems.GetWorld();
            _eventsWorld = systems.GetWorld(WorldsNames.EventsWorldName);
            _filter = _eventsWorld.Filter<UpdateJumpVelocityRequest>().End();
            _updateVelocityRequests = _eventsWorld.GetPool<UpdateJumpVelocityRequest>();
            _jumpVelocities = _defaultWorld.GetPool<JumpVelocity>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter)
            {
                ref var updateJumpVelocityRequest = ref _updateVelocityRequests.Get(entity);

                if (TryUnpack(updateJumpVelocityRequest, out int targetEntity, out _))
                    _jumpVelocities.Get(targetEntity).value = updateJumpVelocityRequest.Value;

                _eventsWorld.DelEntity(entity);
            }
        }

        private bool TryUnpack(UpdateJumpVelocityRequest updateJumpVelocityRequest, out int targetEntity,
            out EcsWorld world) =>
            updateJumpVelocityRequest.TargetEntity.Unpack(out world,out targetEntity);
    }
}