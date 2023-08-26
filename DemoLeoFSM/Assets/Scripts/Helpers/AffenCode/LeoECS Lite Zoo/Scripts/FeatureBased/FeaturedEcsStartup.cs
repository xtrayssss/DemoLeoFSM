using Common;
using Helpers.AffenCode.LeoECS_Lite_Zoo.Scripts.Injection;
using Infrastructure.Services;
using Leopotam.EcsLite;
using Leopotam.EcsLite.UnityEditor;
using UnityEngine;
using Zenject;

namespace Helpers.AffenCode.LeoECS_Lite_Zoo.Scripts.FeatureBased
{
    public abstract class FeaturedEcsStartup : MonoBehaviour
    {
        public EcsWorldProvider worldProvider;

        private EcsSystems _updateSystems;
        private EcsSystems _fixedUpdateSystems;
        private EcsSystems _initSystems;
        private EcsSystems _lateUpdateSystems;

        private IWorldService _worldService;

        [Inject]
        private void Construct(IWorldService worldService) =>
            _worldService = worldService;

        protected void Start()
        {
            InitializeSystems();

#if UNITY_EDITOR
            _updateSystems
                .Add(new EcsWorldDebugSystem(WorldsNames.EventsWorldName))
                .Add(new EcsWorldDebugSystem(WorldsNames.StatesWorldName))
                .Add(new EcsWorldDebugSystem())
                .Add(new EcsSystemsDebugSystem());
#endif
            
            Initialize();
        }

        private void Initialize()
        {
            _worldService.Init(worldProvider.World, new EcsWorld(), new EcsWorld());

            AddFeatures(new FeatureEcsSystems(new EcsSystemsData
            {
                InitSystems = _initSystems,
                UpdateSystems = _updateSystems,
                FixedUpdateSystems = _fixedUpdateSystems,
                LateUpdateSystems = _lateUpdateSystems
            }));

            _updateSystems.AddWorld(_worldService.EventsWorld, WorldsNames.EventsWorldName)
                .AddWorld(_worldService.StatesWorld, WorldsNames.StatesWorldName);

            _initSystems.AddWorld(_worldService.EventsWorld, WorldsNames.EventsWorldName)
                .AddWorld(_worldService.StatesWorld, WorldsNames.StatesWorldName);

            _fixedUpdateSystems.AddWorld(_worldService.EventsWorld, WorldsNames.EventsWorldName)
                .AddWorld(_worldService.StatesWorld, WorldsNames.StatesWorldName);

            _lateUpdateSystems.AddWorld(_worldService.EventsWorld, WorldsNames.EventsWorldName)
                .AddWorld(_worldService.StatesWorld, WorldsNames.StatesWorldName);

            _updateSystems.Inject();
            _initSystems.Inject();
            _fixedUpdateSystems.Inject();
            _lateUpdateSystems.Inject();

            _updateSystems.Init();
            _initSystems.Init();
            _fixedUpdateSystems.Init();
            _lateUpdateSystems.Init();
        }

        private void InitializeSystems()
        {
            _updateSystems = new EcsSystems(worldProvider.World);
            _initSystems = new EcsSystems(worldProvider.World);
            _fixedUpdateSystems = new EcsSystems(worldProvider.World);
            _lateUpdateSystems = new EcsSystems(worldProvider.World);
        }

        private void Update() => 
            _updateSystems?.Run();

        private void FixedUpdate() => 
            _fixedUpdateSystems?.Run();

        private void LateUpdate() => 
            _lateUpdateSystems?.Run();

        private void OnDestroy()
        {
            _updateSystems?.Destroy();
            _updateSystems = null;

            _initSystems?.Destroy();
            _initSystems = null;

            _lateUpdateSystems?.Destroy();
            _lateUpdateSystems = null;

            _fixedUpdateSystems?.Destroy();
            _fixedUpdateSystems = null;
        }

        protected abstract void AddFeatures(FeatureEcsSystems systems);
    }
}