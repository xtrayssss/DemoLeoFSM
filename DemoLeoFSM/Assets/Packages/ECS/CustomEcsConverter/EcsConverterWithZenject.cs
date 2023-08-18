using Leopotam.EcsLite.Packages.ECS.src;
using Packages.ECS.src;
using UnityEngine;
using Zenject;

namespace Packages.ECS.CustomEcsConverter
{
    internal class EcsConverterWithZenject
    {
        public static T InstantiateAndCreateEntity<T>(T original, EcsWorld world, IInstantiator instantiator, out int entity)
            where T : Object
        {
            GameObject obj = instantiator.InstantiatePrefab(original);
            EcsConverter.ConvertObject(obj, world);
            entity = EcsConverter.ConvertObject(obj, world);
            return obj as T;
            
        }

        public static T InstantiateAndCreateEntity<T>(T original, EcsWorld world, Transform parent,
            IInstantiator instantiator, out int entity)
            where T : Object
        {
            GameObject obj = instantiator.InstantiatePrefab(original, parent);
            EcsConverter.ConvertObject(obj, world);
            entity = EcsConverter.ConvertObject(obj, world);
            return obj as T;
        }

        public static T InstantiateAndCreateEntity<T>(T original, EcsWorld world, Transform parent,
            Vector2 spawnPosition,
            IInstantiator instantiator, out int entity)
            where T : Object
        {
            GameObject obj = instantiator.InstantiatePrefab(original, spawnPosition, Quaternion.identity, parent);
            entity = EcsConverter.ConvertObject(obj, world);
            return obj as T;
        }

        public static T InstantiateAndCreateEntity<T>(T original, EcsWorld world, Vector2 spawnPosition,
            IInstantiator instantiator, out int entity)
            where T : Object
        {
            GameObject obj = instantiator.InstantiatePrefab(original, spawnPosition, Quaternion.identity, null);
            entity = EcsConverter.ConvertObject(obj, world);
            return obj as T;
        }
    }
}