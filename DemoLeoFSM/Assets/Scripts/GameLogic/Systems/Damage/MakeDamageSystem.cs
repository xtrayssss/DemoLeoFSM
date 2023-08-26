using Common;
using GameLogic.Components;
using GameLogic.Components.Health;
using GameLogic.Components.Requests.Other;
using GameLogic.Components.Requests.Self;
using GameLogic.Systems.Destroy;
using Leopotam.EcsLite;

namespace GameLogic.Systems.Damage
{
    /// <summary>
    /// The system deals damage to the entity
    /// </summary>
    internal class MakeDamageSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld _defaultWorld;
        private EcsWorld _eventsWorld;
        private EcsFilter _filter;
        private EcsPool<MakeDamageRequest> _damageRequests;
        private EcsPool<Health> _healths;
        private EcsPool<TakingDamageAnalysisSelfRequest> _analysisTakingDamageRequests;
        private EcsPool<DestroyEntitySelfRequest> _destroyRequests;

        public void Init(IEcsSystems systems)
        {
            _defaultWorld = systems.GetWorld();
            _eventsWorld = systems.GetWorld(WorldsNames.EventsWorldName);

            _filter = _eventsWorld.Filter<MakeDamageRequest>().End();

            _healths = _defaultWorld.GetPool<Health>();
            _analysisTakingDamageRequests = _defaultWorld.GetPool<TakingDamageAnalysisSelfRequest>();

            _damageRequests = _eventsWorld.GetPool<MakeDamageRequest>();
            _destroyRequests = _eventsWorld.GetPool<DestroyEntitySelfRequest>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter)
            {
                ref var makeDamageRequest = ref _damageRequests.Get(entity);

                if (TryUnpack(makeDamageRequest, out int damageableEntity))
                {
                    _healths.Get(damageableEntity).value -= makeDamageRequest.Damage;

                    _analysisTakingDamageRequests.Add(damageableEntity);
                }

                _destroyRequests.Add(entity);
            }
        }

        private bool TryUnpack(MakeDamageRequest makeDamageRequest, out int damageableEntity) =>
            makeDamageRequest.DamageableEntity.Unpack(_defaultWorld, out damageableEntity);
    }
}