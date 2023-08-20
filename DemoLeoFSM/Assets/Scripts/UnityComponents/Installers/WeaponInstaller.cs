using Infrastructure.Services.Factories.Weapons;
using Zenject;

namespace UnityComponents.Installers
{
    public class WeaponInstaller : MonoInstaller
    {
        public override void InstallBindings() =>
            BindSwordFactory();

        private void BindSwordFactory() => 
            Container.Bind<ISwordFactory>().To<SwordFactory>().AsSingle();
    }
}