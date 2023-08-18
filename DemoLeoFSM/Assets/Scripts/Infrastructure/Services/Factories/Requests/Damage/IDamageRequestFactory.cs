using Leopotam.EcsLite.Packages.ECS.src;

namespace Infrastructure.Services.Factories.Requests.Damage
{
    internal interface IDamageRequestFactory
    {
        public void CreateDamageRequest(EcsWorld defaultWorld, EcsWorld eventsWorld, int damageDealerEntity,
            int damageableEntity);
    }
}