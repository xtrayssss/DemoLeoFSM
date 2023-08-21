using GameLogic.Components.Health;
using GameLogic.Components.Jump;
using GameLogic.Components.Movement;
using GameLogic.Components.Weapon;
using GameLogic.Configs.Hero;
using GameLogic.Configs.Weapons;
using GameLogic.EntityViews;
using GameLogic.Factories.Detections;
using GameLogic.Factories.Weapons;
using GameLogic.Services.Data;
using Helpers.ConverterToEntity;
using Leopotam.EcsLite;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GameLogic.Factories.Hero
{
    internal class HeroFactory : IHeroFactory
    {
        private readonly HeroEntityView _heroEntityView;
        private readonly IStaticDataService _staticDataService;
        private readonly ISwordFactory _swordFactory;
        private readonly IDetectionFactory _detectionFactory;

        public HeroFactory(HeroEntityView heroEntityView, IStaticDataService staticDataService,
            ISwordFactory swordFactory, IDetectionFactory detectionFactory)
        {
            _heroEntityView = heroEntityView;
            _staticDataService = staticDataService;
            _swordFactory = swordFactory;
            _detectionFactory = detectionFactory;
        }

        public GameObject CreateHero(IEcsSystems system)
        {
            InitializeWorlds(system, out EcsWorld defaultWorld);

            int entity = GetConvertedEntity();
            InitializeEntityView(entity, defaultWorld);

            HeroConfig heroConfig = GetHeroData();

            SetHeroPosition(heroConfig.spawnPosition);
            SetCameraFollow(heroConfig, _heroEntityView.transform);

            InitializeComponents(defaultWorld, entity, heroConfig);

            //CreateGroundCheckPoint(system, entity, heroConfig);
            CreateSword(defaultWorld, entity, system);

            return _heroEntityView.gameObject;
        }

        private void InitializeEntityView(int entity, EcsWorld defaultWorld) =>
            _heroEntityView.Init(entity, defaultWorld);

        private int GetConvertedEntity() =>
            _heroEntityView.GetComponentInChildren<ConverterToEntity>().Convert();

        private void InitializeComponents(EcsWorld defaultWorld, int entity, HeroConfig heroConfig)
        {
            defaultWorld.GetPool<MovementSpeed>().Get(entity).value = heroConfig.MovementSpeed;
            defaultWorld.GetPool<JumpGravity>().Get(entity).value = heroConfig.JumpGravity;
            defaultWorld.GetPool<JumpVelocity>().Get(entity).value = heroConfig.JumpVelocity;
            defaultWorld.GetPool<JumpMaxVelocity>().Get(entity).value = heroConfig.JumpVelocity;
            defaultWorld.GetPool<Health>().Get(entity).value = heroConfig.Health;
        }

        private void CreateSword(EcsWorld defaultWorld, int entity, IEcsSystems system)
        {
            Transform weaponHolder = defaultWorld.GetPool<WeaponHolder>().Get(entity).value;

            _swordFactory.CreateSword(system, WeaponTypeId.BronzeSword,
                weaponHolder.position, weaponHolder);
        }

        private void InitializeWorlds(IEcsSystems system, out EcsWorld defaultWorld) =>
            defaultWorld = system.GetWorld();

        private void SetHeroPosition(Vector2 spawnPosition) =>
            _heroEntityView.transform.position = spawnPosition;

        private void CreateGroundCheckPoint(IEcsSystems system, int entity, HeroConfig heroConfig) =>
            _detectionFactory.CreateGroundCheckPoint(system, entity, _heroEntityView.transform,
                heroConfig.GroundDetectionConfig);

        private void SetCameraFollow(HeroConfig heroConfig, Transform heroGO) =>
            Object.Instantiate(heroConfig.Camera)
                .Follow = heroGO;

        private HeroConfig GetHeroData() =>
            _staticDataService.GetHeroData();
    }
}