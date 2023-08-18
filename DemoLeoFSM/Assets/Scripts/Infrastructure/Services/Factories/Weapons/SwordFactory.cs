using Components.Attack;
using Components.Buffers;
using Components.CoolDowns;
using Components.Damage;
using Infrastructure.Services.Data;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Packages.ECS.src;
using Packages.ECS.src;
using UnityComponents.Configs.Weapons;
using UnityComponents.Configs.Weapons.Swords;
using UnityComponents.Views;
using UnityEngine;
using Zenject;

namespace Infrastructure.Services.Factories.Weapons
{
    internal class SwordFactory : ISwordFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IStaticDataService _staticDataService;

        public SwordFactory(IInstantiator instantiator, IStaticDataService staticDataService)
        {
            _instantiator = instantiator;
            _staticDataService = staticDataService;
        }

        public void CreateSword(EcsWorld defaultWorld, EcsWorld eventsWorld, WeaponTypeId weaponTypeId,
            Vector2 position, Transform parent)
        {
            SwordConfig weaponConfig = _staticDataService.GetWeaponData<SwordConfig>(weaponTypeId);
            
            GameObject swordGO = InstantiateSword(position, weaponConfig, parent);

            int entity = EcsConverter.CreateEntity(swordGO.GetComponentInChildren<ComponentsContainer>(),
                swordGO.transform, defaultWorld);

            defaultWorld.GetPool<Range>().Get(entity).value = weaponConfig.RangeAttack;
            defaultWorld.GetPool<HitLayer>().Get(entity).value = weaponConfig.HitLayer;
            defaultWorld.GetPool<MaximumHits>().Get(entity).value = weaponConfig.MAXHitSize;
            defaultWorld.GetPool<Damage>().Get(entity).value = weaponConfig.Damage;
            defaultWorld.GetPool<CoolDownAttack>().Get(entity).value = weaponConfig.CoolDown;
            defaultWorld.GetPool<HitBuffer>().Get(entity).value = new Collider2D[weaponConfig.MAXHitSize];

            swordGO.GetComponent<WeaponEntityView>().Init(entity, defaultWorld);
        }

        private GameObject InstantiateSword(Vector2 position, WeaponConfig weaponConfig, Transform parent) =>
            _instantiator.InstantiatePrefab(weaponConfig.PrefabWeapon, position, Quaternion.identity, parent);
    }
}