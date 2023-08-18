using Common;
using Infrastructure.Services.Asset;
using Infrastructure.Services.CancellationToken;
using Infrastructure.Services.Coroutine;
using Infrastructure.Services.Data;
using Infrastructure.Services.Drawers;
using Infrastructure.Services.Factories.Detections;
using Infrastructure.Services.Factories.Enemies;
using Infrastructure.Services.Factories.Requests.Damage;
using Infrastructure.Services.Factories.Requests.Velocity;
using Infrastructure.Services.Factories.Transition;
using Infrastructure.Services.Input;
using Infrastructure.Services.Timer;
using Zenject;

namespace UnityComponents.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindStaticDataService();
            BindAssetProviderService();
            BindTimerService();
            BindDetectionFactory();
            BindInputService();
            BindWorldService();
            BindTransitionFactory();
            BindStateMachineFactory();
            BindVelocityRequestsFactory();
            BindEnemyFactory();
            BindTreeFactory();
            BindDamageRequestFactory();
            BindCoroutineRunner();
            BindDrawerSprite();
            BindCancellationTokenService();
        }

        private void BindCancellationTokenService() => 
            Container.Bind<ICancellationTokenService>().To<CancellationTokenService>().AsSingle();

        private void BindDrawerSprite() => 
            Container.Bind<IColorSprite>().To<ColorSprite>().AsSingle();

        private void BindCoroutineRunner() =>
            Container.Bind<ICoroutineRunner>().FromComponentInNewPrefabResource(AssetPaths.CoroutineRunnerPath)
                .AsSingle();

        private void BindDamageRequestFactory() =>
            Container.Bind<IDamageRequestFactory>().To<DamageRequestFactory>().AsSingle();

        private void BindEnemyFactory() =>
            Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle();

        private void BindTreeFactory() =>
            Container.BindInterfacesAndSelfTo<EnemyTreeFactory>().AsSingle();

        private void BindStateMachineFactory() =>
            Container.Bind<IStateMachineFactory>().To<StateMachineFactory>().AsSingle();

        private void BindTransitionFactory() =>
            Container.Bind<ITransitionFactory>().To<TransitionFactory>().AsSingle();

        private void BindWorldService() =>
            Container.Bind<IWorldService>().To<WorldService>().AsSingle();

        private void BindVelocityRequestsFactory() =>
            Container.Bind<IVelocityRequestsFactory>().To<VelocityRequestsFactory>().AsSingle();

        private void BindDetectionFactory() =>
            Container.Bind<IDetectionFactory>().To<DetectionFactory>().AsSingle();

        private void BindInputService() =>
            Container.BindInterfacesAndSelfTo<InputService>().AsSingle();

        private void BindTimerService() =>
            Container.Bind<IObservableTimerService>().To<ObservableTimerService>().AsSingle();

        private void BindAssetProviderService() =>
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();

        private void BindStaticDataService() =>
            Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
    }
}