using GameLogic.Components.Requests.Other;
using Leopotam.EcsLite;

namespace GameLogic.Factories.Requests.Damage
{
    internal class DamageRequestFactory : IDamageRequestFactory
    {
        public void CreateDamageRequest(EcsWorld defaultWorld, EcsWorld eventsWorld, int damageDealerEntity,
            int damageableEntity)
        {
            int requestEntity = eventsWorld.NewEntity();

            ref var makeDamageRequest = ref eventsWorld.GetPool<MakeDamageRequest>().Add(requestEntity);
            makeDamageRequest.Damage = defaultWorld.GetPool<GameLogic.Components.Damage.Damage>().Get(damageDealerEntity).value;
            makeDamageRequest.DamageableEntity = defaultWorld.PackEntity(damageableEntity);
            makeDamageRequest.DamageDealerEntity = defaultWorld.PackEntity(damageDealerEntity);
        }
    }
}