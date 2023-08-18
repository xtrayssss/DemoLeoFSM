using UnityComponents.ObjectContainers;
using UnityEngine;
using Zenject;

namespace UnityComponents.Installers
{
    public class SceneObjectContainerInstaller : MonoInstaller
    {
        [SerializeField] private SceneObjectContainer sceneObjectContainer;
        public override void InstallBindings() => 
            BindSceneObjectContainer();

        private void BindSceneObjectContainer() => 
            Container.Bind<SceneObjectContainer>().FromInstance(sceneObjectContainer).AsSingle();
    }
}