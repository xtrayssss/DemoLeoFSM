﻿using GameLogic.Factories.Weapons;
using Zenject;

namespace GameLogic.Installers
{
    public class WeaponInstaller : MonoInstaller
    {
        public override void InstallBindings() =>
            BindSwordFactory();

        private void BindSwordFactory() => 
            Container.Bind<ISwordFactory>().To<SwordFactory>().AsSingle();
    }
}