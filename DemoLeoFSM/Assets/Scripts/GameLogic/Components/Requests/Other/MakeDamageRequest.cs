using Leopotam.EcsLite;

namespace GameLogic.Components.Requests.Other
{
    internal struct MakeDamageRequest
    {
        public float Damage;

        public EcsPackedEntity DamageDealerEntity;
        public EcsPackedEntity DamageableEntity;
    }
}