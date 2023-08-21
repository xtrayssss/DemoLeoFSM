using GameLogic.Components.Attack;
using GameLogic.Components.Buffers;
using GameLogic.Components.Cooldowns;
using GameLogic.Components.Damage;
using GameLogic.Configs.Weapons;
using GameLogic.Configs.Weapons.Swords;
using GameLogic.EntityViews;
using GameLogic.Services.Data;
using Helpers.ConverterToEntity;
using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

namespace GameLogic.Factories.Weapons
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

        public void CreateSword(IEcsSystems system, WeaponTypeId weaponTypeId,
            Vector2 position, Transform parent)
        {
            InitializeWorlds(system, out EcsWorld defaultWorld);

            SwordConfig weaponConfig = GetWeaponData(weaponTypeId);

            GameObject swordGO = InstantiateSword(position, weaponConfig, parent);

            int entity = CreateConvertedEntity(swordGO);

            InitializeComponents(defaultWorld, entity, weaponConfig);

            InitializeEntityView(defaultWorld, swordGO, entity);
        }


        private void InitializeComponents(EcsWorld defaultWorld, int entity, SwordConfig weaponConfig)
        {
            defaultWorld.GetPool<Range>().Get(entity).value = weaponConfig.RangeAttack;
            defaultWorld.GetPool<HitLayer>().Get(entity).value = weaponConfig.HitLayer;
            defaultWorld.GetPool<MaximumHits>().Get(entity).value = weaponConfig.MAXHitSize;
            defaultWorld.GetPool<Damage>().Get(entity).value = weaponConfig.Damage;
            defaultWorld.GetPool<CoolDownAttack>().Get(entity).value = weaponConfig.CoolDown;
            defaultWorld.GetPool<HitBuffer>().Get(entity).value = new Collider2D[weaponConfig.MAXHitSize];
        }

        private int CreateConvertedEntity(GameObject swordGO) =>
            swordGO.GetComponentInChildren<ConverterToEntity>().Convert();

        private void InitializeWorlds(IEcsSystems system, out EcsWorld defaultWorld) =>
            defaultWorld = system.GetWorld();

        private void InitializeEntityView(EcsWorld defaultWorld, GameObject swordGO, int entity) =>
            swordGO.GetComponent<WeaponEntityView>().Init(entity, defaultWorld);

        private SwordConfig GetWeaponData(WeaponTypeId weaponTypeId) =>
            _staticDataService.GetWeaponData<SwordConfig>(weaponTypeId);

        private GameObject InstantiateSword(Vector2 position, WeaponConfig weaponConfig, Transform parent) =>
            _instantiator.InstantiatePrefab(weaponConfig.PrefabWeapon, position, Quaternion.identity, parent);
    }
}