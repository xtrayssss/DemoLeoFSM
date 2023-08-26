using Leopotam.EcsLite;
using UnityEngine;

namespace Helpers.AffenCode.LeoECS_Lite_Zoo.Scripts.Systems
{
    public class SyncToUnityTransformSystem : IEcsPreInitSystem, IEcsRunSystem
    {
        public void PreInit(IEcsSystems systems)
        {
            SyncTransforms(systems);
        }

        public void Run(IEcsSystems systems)
        {
            SyncTransforms(systems);
        }

        private static void SyncTransforms(IEcsSystems systems)
        {
            var world = systems.GetWorld();

            var ecsTransforms = world.GetPool<EcsTransform>();
            var transformRefs = world.GetPool<TransformRef>();
            var rectTransformRefs = world.GetPool<RectTransformRef>();
            var rigidbodyRefs = world.GetPool<RigidbodyRef>();
            var rigidbody2DRefs = world.GetPool<Rigidbody2DRef>();

            var globalTransformFilter = world.Filter<EcsTransform>().Inc<TransformRef>().Exc<IgnoreTransformSync>().Exc<LocalTransformSync>().End();
            foreach (var entity in globalTransformFilter)
            {
                ref var ecsTransform = ref ecsTransforms.Get(entity);
                ref var unityTransform = ref transformRefs.Get(entity);
                unityTransform.Value.position = ecsTransform.Position;
                unityTransform.Value.rotation = ecsTransform.Rotation;
                unityTransform.Value.localScale = ecsTransform.Scale;
            }

            var localTransformFilter = world.Filter<EcsTransform>().Inc<TransformRef>().Exc<IgnoreTransformSync>().Inc<LocalTransformSync>().End();
            foreach (var entity in localTransformFilter)
            {
                ref var ecsTransform = ref ecsTransforms.Get(entity);
                ref var unityTransform = ref transformRefs.Get(entity);
                unityTransform.Value.localPosition = ecsTransform.Position;
                unityTransform.Value.localRotation = ecsTransform.Rotation;
                unityTransform.Value.localScale = ecsTransform.Scale;
            }

            var rectTransformFilter = world.Filter<EcsTransform>().Inc<RectTransformRef>().Exc<IgnoreTransformSync>().End();
            foreach (var entity in rectTransformFilter)
            {
                ref var ecsTransform = ref ecsTransforms.Get(entity);
                ref var rectTransformRef = ref rectTransformRefs.Get(entity);
                rectTransformRef.Value.anchoredPosition = ecsTransform.Position;
                rectTransformRef.Value.rotation = ecsTransform.Rotation;
                rectTransformRef.Value.localScale = ecsTransform.Scale;
            }

            var globalRigidbodyFilter = world.Filter<EcsTransform>().Inc<RigidbodyRef>().Inc<IgnoreTransformSync>().Exc<IgnoreRigidbodySync>().Exc<LocalTransformSync>().End();
            foreach (var entity in globalRigidbodyFilter)
            {
                ref var ecsTransform = ref ecsTransforms.Get(entity);
                ref var unityTransform = ref transformRefs.Get(entity);
                ref var rigidbodyRef = ref rigidbodyRefs.Get(entity);
                rigidbodyRef.Value.position = ecsTransform.Position;
                rigidbodyRef.Value.rotation = ecsTransform.Rotation;
                unityTransform.Value.localScale = ecsTransform.Scale;
            }

            var localRigidbodyFilter = world.Filter<EcsTransform>().Inc<RigidbodyRef>().Inc<IgnoreTransformSync>().Exc<IgnoreRigidbodySync>().Inc<LocalTransformSync>().End();
            foreach (var entity in localRigidbodyFilter)
            {
                ref var ecsTransform = ref ecsTransforms.Get(entity);
                ref var unityTransform = ref transformRefs.Get(entity);
                unityTransform.Value.localPosition = ecsTransform.Position;
                unityTransform.Value.localRotation = ecsTransform.Rotation;
                unityTransform.Value.localScale = ecsTransform.Scale;
            }

            var globalRigidbody2DFilter = world.Filter<EcsTransform>().Inc<Rigidbody2DRef>().Inc<IgnoreTransformSync>().Exc<IgnoreRigidbodySync>().Exc<LocalTransformSync>().End();
            foreach (var entity in globalRigidbody2DFilter)
            {
                ref var ecsTransform = ref ecsTransforms.Get(entity);
                ref var unityTransform = ref transformRefs.Get(entity);
                ref var rigidbody2DRef = ref rigidbody2DRefs.Get(entity);
                rigidbody2DRef.Value.position = ecsTransform.Position;
                rigidbody2DRef.Value.rotation = ecsTransform.Rotation.eulerAngles.z;
                unityTransform.Value.localScale = ecsTransform.Scale;
            }

            var localRigidbody2DFilter = world.Filter<EcsTransform>().Inc<Rigidbody2DRef>().Inc<IgnoreTransformSync>().Exc<IgnoreRigidbodySync>().Inc<LocalTransformSync>().End();
            foreach (var entity in localRigidbody2DFilter)
            {
                ref var ecsTransform = ref ecsTransforms.Get(entity);
                ref var unityTransform = ref transformRefs.Get(entity);
                ref var rigidbody2DRef = ref rigidbody2DRefs.Get(entity);
                unityTransform.Value.localPosition = ecsTransform.Position;
                unityTransform.Value.localRotation = Quaternion.Euler(ecsTransform.Rotation.eulerAngles);
                unityTransform.Value.localScale = ecsTransform.Scale;
            }
        }
    }
}