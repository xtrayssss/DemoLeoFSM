using Leopotam.EcsLite;

namespace GameLogic.Factories.Requests.Damage
{
    internal interface IDamageRequestFactory
    {
        public void CreateDamageRequest(EcsWorld defaultWorld, EcsWorld eventsWorld, int damageDealerEntity,
            int damageableEntity);
    }
}