using Helpers.AffenCode.LeoECS_Lite_Zoo.Scripts.Injection;
using Helpers.AffenCode.LeoECS_Lite_Zoo.Scripts.Systems;
using Leopotam.EcsLite;
using UnityEngine;

namespace Helpers.AffenCode.LeoECS_Lite_Zoo.Scripts
{
    public abstract class EcsStartup : MonoBehaviour
    {
        public EcsWorldProvider WorldProvider;

        public bool InitializeOnStart = true;

        private EcsSystems _updateSystems;
        private EcsSystems _lateUpdateSystems;
        private EcsSystems _fixedUpdateSystems;

        private void Start()
        {
            if (InitializeOnStart)
            {
                Initialize();
            }
        }

        public void Initialize()
        {
            _updateSystems = new EcsSystems(WorldProvider.World);
            _updateSystems.Add(new SyncFromUnityTransformSystem());
            AddUpdateSystems(_updateSystems);
            _updateSystems.Add(new SyncToUnityTransformSystem());
            _updateSystems.Inject();
            _updateSystems.Init();
            
            _lateUpdateSystems = new EcsSystems(WorldProvider.World);
            _lateUpdateSystems.Add(new SyncFromUnityTransformSystem());
            AddLateUpdateSystems(_lateUpdateSystems);
            _lateUpdateSystems.Add(new SyncToUnityTransformSystem());
            _lateUpdateSystems.Inject();
            _lateUpdateSystems.Init();
            
            _fixedUpdateSystems = new EcsSystems(WorldProvider.World);
            _fixedUpdateSystems.Add(new SyncFromUnityTransformSystem());
            AddFixedUpdateSystems(_fixedUpdateSystems);
            _fixedUpdateSystems.Add(new SyncToUnityTransformSystem());
            _fixedUpdateSystems.Inject();
            _fixedUpdateSystems.Init();
        }

        private void Update()
        {
            _updateSystems?.Run();
        }

        private void LateUpdate()
        {
            _lateUpdateSystems?.Run();
        }

        private void FixedUpdate()
        {
            _fixedUpdateSystems?.Run();
        }

        private void OnDestroy()
        {
            _updateSystems?.Destroy();
            _updateSystems = null;
            
            _lateUpdateSystems?.Destroy();
            _lateUpdateSystems = null;
            
            _fixedUpdateSystems?.Destroy();
            _fixedUpdateSystems = null;
        }

        protected abstract void AddUpdateSystems(EcsSystems ecsSystems);
        protected abstract void AddLateUpdateSystems(EcsSystems ecsSystems);
        protected abstract void AddFixedUpdateSystems(EcsSystems ecsSystems);
    }
}