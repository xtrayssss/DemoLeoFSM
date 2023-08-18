using Systems.Analyze;
using Systems.Damage;
using Systems.Destroy;
using Systems.Detection;
using Systems.Flip;
using Systems.Inits;
using Systems.Input;
using Systems.Jump;
using Systems.Movements;
using Systems.StateMachine;
using Systems.Updates;
using Common;
using Infrastructure.Services.Data;
using Infrastructure.Services.Factories.Enemies;
using Infrastructure.Services.Factories.Hero;
using Infrastructure.Services.Factories.Requests.Damage;
using Infrastructure.Services.Input;
using Leopotam.EcsLite.Packages.ECS.src;
#if UNITY_EDITOR
using Leopotam.EcsLite.UnityEditor.Packages.ECS.Runtime;
#endif
using UnityComponents.ObjectContainers;
using UnityEngine;
using Zenject;

namespace UnityComponents
{
    public class Startup : MonoBehaviour
    {
        private EcsWorld _defaultWorld;
        private EcsWorld _statesWorlds;
        private EcsWorld _eventsWorld;
        private IEcsSystems _initSystems;
        private IEcsSystems _updateSystems;
        private IEcsSystems _fixedUpdateSystems;
        private IHeroFactory _heroFactory;
        private IInputService _inputService;
        private IStaticDataService _staticDataService;
        private IWorldService _worldService;
        private IEnemyFactory _enemyFactory;
        private SceneObjectContainer _sceneObjectContainer;
        private IDamageRequestFactory _damageRequestFactory;

        [Inject]
        private void Construct(IHeroFactory heroFactory, IInputService inputService,
            IStaticDataService staticDataService, IWorldService worldService, IEnemyFactory enemyFactory,
            SceneObjectContainer sceneObjectContainer, IDamageRequestFactory damageRequestFactory)
        {
            _sceneObjectContainer = sceneObjectContainer;
            _enemyFactory = enemyFactory;
            _worldService = worldService;
            _heroFactory = heroFactory;
            _inputService = inputService;
            _staticDataService = staticDataService;
            _damageRequestFactory = damageRequestFactory;
        }

        private void Awake()
        {
            _defaultWorld = new EcsWorld();
            _eventsWorld = new EcsWorld();
            _statesWorlds = new EcsWorld();

            _worldService.Init(_defaultWorld, _eventsWorld, _statesWorlds);
            InitializeSystems();

            AddSystems();

#if UNITY_EDITOR
            _updateSystems
                .Add(new EcsWorldDebugSystem(WorldsNames.EventsWorldName))
                .Add(new EcsWorldDebugSystem(WorldsNames.StatesWorldName))
                .Add(new EcsWorldDebugSystem())
                .Add(new EcsSystemsDebugSystem());
#endif

            _initSystems.Init();
            _updateSystems.Init();
            _fixedUpdateSystems.Init();
        }

        private void Update() =>
            _updateSystems?.Run();

        private void FixedUpdate() =>
            _fixedUpdateSystems?.Run();

        private void OnDestroy() =>
            CleanupEnvironment();

        private void InitializeSystems()
        {
            _initSystems = new EcsSystems(_defaultWorld);
            _updateSystems = new EcsSystems(_defaultWorld);
            _fixedUpdateSystems = new EcsSystems(_defaultWorld);
        }

        private void AddSystems()
        {
            _initSystems
                .AddWorld(_eventsWorld, WorldsNames.EventsWorldName)
                .Add(new InitLevelSystem(_heroFactory, _staticDataService, _enemyFactory, _sceneObjectContainer));

            _updateSystems
                .AddWorld(_eventsWorld, WorldsNames.EventsWorldName)
                .AddWorld(_statesWorlds, WorldsNames.StatesWorldName)
                .Add(new HeroInputSystem(_inputService))
                .Add(new DirectionCalculationSystem())
                .Add(new FlipSystem())
                .Add(new UpdateMovementVelocitySystem())
                .Add(new GroundCollisionAnalyzeSystem())
                .Add(new UpdateJumpVelocitySystem())
                
                //State machine
                .Add(new CheckConditionGroupTransitionsSystem())
                .Add(new CheckConditionTransitionsSystem())
                .Add(new ChangeCurrentStateSystem())
                .Add(new CleanupTransitionsActivitySystem())
                .Add(new SetupTransitionsActivitySystem())
                .Add(new UpdateCurrentStateSystem())
                
                .Add(new CreateDetectionAnalyzeRequestSystem())

                //Damage
                .Add(new AnalyzeDetectionDamageRequests(_damageRequestFactory))
                .Add(new MakeDamageSystem())
                
                .Add(new ColorSpriteInHurt())
                
                //Destroyers
                .Add(new DestroyGameObjectSystem())
                .Add(new DestroyEntitySystem());

            _fixedUpdateSystems
                .AddWorld(_eventsWorld, WorldsNames.EventsWorldName)
                .Add(new MovementSystem())
                .Add(new DetectionCircleSystem())
                .Add(new DetectionNonAllocCircleSystem())
                .Add(new JumpSystem());
        }

        private void CleanupEnvironment()
        {
            if (SystemsIsNotNull(_initSystems))
                Cleanup(ref _initSystems);

            if (SystemsIsNotNull(_updateSystems))
                Cleanup(ref _updateSystems);

            if (SystemsIsNotNull(_fixedUpdateSystems))
                Cleanup(ref _fixedUpdateSystems);

            if (WorldIsNotNull())
                Cleanup();
        }

        private void Cleanup(ref IEcsSystems systems)
        {
            systems.Destroy();
            systems = null;
        }

        private void Cleanup()
        {
            _defaultWorld.Destroy();
            _defaultWorld = null;
        }

        private bool WorldIsNotNull() =>
            _defaultWorld != null;

        private bool SystemsIsNotNull(IEcsSystems systems) =>
            systems != null;
    }
}