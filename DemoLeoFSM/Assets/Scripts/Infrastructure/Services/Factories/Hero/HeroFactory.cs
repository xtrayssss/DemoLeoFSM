using AB_Utility.FromSceneToEntityConverter;
using Common;
using Components.Health;
using Components.Jump;
using Components.Movement;
using Components.Weapon;
using Infrastructure.Services.Data;
using Infrastructure.Services.Factories.Detections;
using Infrastructure.Services.Factories.Weapons;
using Leopotam.EcsLite;
using UnityComponents.Configs.Hero;
using UnityComponents.Views;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Infrastructure.Services.Factories.Hero
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
            // EcsWorld defaultWorld = system.GetWorld();
            // EcsWorld eventsWorld = system.GetWorld(WorldsNames.EventsWorldName);
            //
            // HeroConfig heroConfig = _staticDataService.GetHeroData();
            //
            // int entity = EcsConverter.CreateEntity(_heroEntityView.GetComponentInChildren<ComponentsContainer>(),
            //     _heroEntityView.transform,
            //     system.GetWorld());
            //
            // _heroEntityView.transform.position = new Vector3(1,1,1);
            //
            // _heroEntityView.Init(entity, defaultWorld);
            //
            // SetCameraFollow(heroConfig, _heroEntityView.transform);
            //
            // defaultWorld.GetPool<MovementSpeed>().Get(entity).value = heroConfig.MovementSpeed;
            // defaultWorld.GetPool<JumpGravity>().Get(entity).value = heroConfig.JumpGravity;
            // defaultWorld.GetPool<JumpVelocity>().Get(entity).value = heroConfig.JumpVelocity;
            // defaultWorld.GetPool<JumpMaxVelocity>().Get(entity).value = heroConfig.JumpVelocity;
            // defaultWorld.GetPool<Health>().Get(entity).value = heroConfig.Health;
            //
            // //CreateGroundCheckPoint(defaultWorld, entity, heroConfig);
            //
            // CreateSword(defaultWorld, entity, eventsWorld);
            //
            // return _heroEntityView.gameObject;

            return null;
        }

        private void CreateGroundCheckPoint(EcsWorld defaultWorld, int entity, HeroConfig heroConfig) =>
            _detectionFactory.CreateGroundCheckPoint(defaultWorld, entity, _heroEntityView.transform,
                heroConfig.GroundDetectionConfig);

        private void CreateSword(EcsWorld defaultWorld, int entity, EcsWorld eventsWorld)
        {
            Transform weaponHolder = defaultWorld.GetPool<WeaponHolder>().Get(entity).value;

            _swordFactory.CreateSword(defaultWorld, eventsWorld, WeaponTypeId.BronzeSword,
                weaponHolder.position, weaponHolder);
        }

        private void SetCameraFollow(HeroConfig heroConfig, Transform heroGO) =>
            Object.Instantiate(heroConfig.Camera)
                .Follow = heroGO;
    }
}