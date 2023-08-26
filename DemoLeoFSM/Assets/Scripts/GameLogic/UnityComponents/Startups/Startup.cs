using GameLogic.Factories.Enemies;
using GameLogic.Factories.Hero;
using GameLogic.Factories.Requests.Damage;
using GameLogic.Services.Data;
using GameLogic.Services.Input;
using GameLogic.UnityComponents.ObjectContainers;
using GameLogic.UnityComponents.Startups.Features;
using Helpers.AffenCode.LeoECS_Lite_Zoo.Scripts.FeatureBased;
using Zenject;

namespace GameLogic.UnityComponents.Startups
{
    public class Startup : FeaturedEcsStartup
    {
        private IHeroFactory _heroFactory;
        private IInputService _inputService;
        private IStaticDataService _staticDataService;
        private IEnemyFactory _enemyFactory;
        private SceneObjectContainer _sceneObjectContainer;
        private IDamageRequestFactory _damageRequestFactory;

        [Inject]
        private void Construct(
            IHeroFactory heroFactory,
            IInputService inputService,
            IStaticDataService staticDataService,
            IEnemyFactory enemyFactory,
            SceneObjectContainer sceneObjectContainer,
            IDamageRequestFactory damageRequestFactory)
        {
            _sceneObjectContainer = sceneObjectContainer;
            _enemyFactory = enemyFactory;
            _heroFactory = heroFactory;
            _inputService = inputService;
            _staticDataService = staticDataService;
            _damageRequestFactory = damageRequestFactory;
        }

        protected override void AddFeatures(FeatureEcsSystems systems) =>
            systems
                .Add(new InitGameWorldFeature(_heroFactory, _staticDataService, _sceneObjectContainer, _enemyFactory))
                .Add(new InputFeature(_inputService))
                .Add(new MovementFeature())
                .Add(new DamageFeature())
                .Add(new StateMachineFeature())
                .Add(new DetectionFeature())
                .Add(new AnalysisFeature(_damageRequestFactory))
                .Add(new JumpFeature())
                .Add(new DestroyFeature())
                .End();
    }
}