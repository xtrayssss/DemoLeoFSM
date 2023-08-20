using Common;
using Components.Health;
using Components.Requests.Other;
using Components.Requests.Self;
using Leopotam.EcsLite;

namespace Systems.Damage
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
        private EcsPool<AnalyzeTakeDamageSelfRequest> _analyzeTakeDamageSelfRequests;

        public void Init(IEcsSystems systems)
        {
            _defaultWorld = systems.GetWorld();
            _eventsWorld = systems.GetWorld(WorldsNames.EventsWorldName);

            _filter = _eventsWorld.Filter<MakeDamageRequest>().End();

            _damageRequests = _eventsWorld.GetPool<MakeDamageRequest>();
            _healths = _defaultWorld.GetPool<Health>();
            _analyzeTakeDamageSelfRequests = _defaultWorld.GetPool<AnalyzeTakeDamageSelfRequest>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter)
            {
                ref var makeDamageRequest = ref _damageRequests.Get(entity);

                if (TryUnpack(makeDamageRequest, out int damageableEntity))
                {
                    _healths.Get(damageableEntity).value -= makeDamageRequest.Damage;
                    
                    _analyzeTakeDamageSelfRequests.Add(damageableEntity);
                }
 
                _eventsWorld.DelEntity(entity);
            }
        }

        private bool TryUnpack(MakeDamageRequest makeDamageRequest, out int damageableEntity) =>
            makeDamageRequest.DamageableEntity.Unpack(_defaultWorld, out damageableEntity);
    }
}