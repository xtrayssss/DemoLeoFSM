using Leopotam.EcsLite;
using Leopotam.EcsLite.Packages.ECS.src;
using UnityEngine;

namespace Infrastructure.Services.Factories.Weapons
{
    internal interface ISwordFactory
    {
        public void CreateSword(EcsWorld defaultWorld, EcsWorld eventsWorld, WeaponTypeId weaponTypeId,
            Vector2 position, Transform parent);
    }
}