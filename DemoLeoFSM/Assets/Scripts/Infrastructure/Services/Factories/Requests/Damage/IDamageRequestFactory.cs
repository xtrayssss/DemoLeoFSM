using Leopotam.EcsLite;

namespace Infrastructure.Services.Factories.Requests.Damage
{
    internal interface IDamageRequestFactory
    {
        public void CreateDamageRequest(EcsWorld defaultWorld, EcsWorld eventsWorld, int damageDealerEntity,
            int damageableEntity);
    }
}