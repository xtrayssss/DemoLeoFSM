using Components;
using Components.Grounds;
using Components.Owners;
using Components.Requests.Self;
using Leopotam.EcsLite;

namespace Systems.Analyze
{
    internal class GroundCollisionAnalyzeSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld _world;
        private EcsFilter _filter;
        private EcsPool<Grounded> _grounded;
        private EcsPool<OwnerComponent> _owners;
        private EcsPool<CircleOverlapAnalyzeSelfRequest> _analyzeRequests;

        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _filter = _world.Filter<CircleOverlapAnalyzeSelfRequest>().Inc<GroundPointMarker>().Inc<OwnerComponent>()
                .End();
            _grounded = _world.GetPool<Grounded>();
            _owners = _world.GetPool<OwnerComponent>();
            _analyzeRequests = _world.GetPool<CircleOverlapAnalyzeSelfRequest>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter)
            {
                if (TryUnpack(entity, out int ownerEntity))
                    _grounded.Get(ownerEntity).value = _analyzeRequests.Get(entity).Value;

                _analyzeRequests.Del(entity);
            }
        }

        private bool TryUnpack(int entity, out int ownerEntity) =>
            _owners.Get(entity).Value.Unpack(out _world, out ownerEntity);
    }
}