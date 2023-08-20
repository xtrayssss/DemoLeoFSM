using Components.Requests.Other;
using Leopotam.EcsLite;

namespace Infrastructure.Services.Factories.Requests.Damage
{
    internal class DamageRequestFactory : IDamageRequestFactory
    {
        public void CreateDamageRequest(EcsWorld defaultWorld, EcsWorld eventsWorld, int damageDealerEntity,
            int damageableEntity)
        {
            int requestEntity = eventsWorld.NewEntity();

            ref var makeDamageRequest = ref eventsWorld.GetPool<MakeDamageRequest>().Add(requestEntity);
            makeDamageRequest.Damage = defaultWorld.GetPool<Components.Damage.Damage>().Get(damageDealerEntity).value;
            makeDamageRequest.DamageableEntity = defaultWorld.PackEntity(damageableEntity);
            makeDamageRequest.DamageDealerEntity = defaultWorld.PackEntity(damageDealerEntity);
        }
    }
}