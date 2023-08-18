using System;
using Leopotam.EcsLite.Packages.ECS.src;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Packages.ECS.src
{
    public class EcsConverter
    {
        public static T InstantiateAndCreateEntity<T>
        (T original, Vector3 position, Quaternion rotation, Transform parent,
            EcsWorld world)
            where T : Object
        {
            var obj = Object.Instantiate(original, position, rotation, parent);
            ConvertObject(obj as GameObject, world);
            return obj;
        }

        public static T InstantiateAndCreateEntity<T>
            (T original, Vector3 position, Quaternion rotation, EcsWorld world)
            where T : Object
        {
            var obj = Object.Instantiate(original, position, rotation);
            ConvertObject(obj as GameObject, world);
            return obj;
        }

        public static T InstantiateAndCreateEntity<T>
            (T original, Transform parent, EcsWorld world, bool worldPositionStay)
            where T : Object
        {
            var obj = Object.Instantiate(original, parent, worldPositionStay);
            ConvertObject(obj as GameObject, world);
            return obj;
        }

        public static T InstantiateAndCreateEntity<T>(T original, Transform parent, EcsWorld world, out int entity)
            where T : Object
        {
            var obj = Object.Instantiate(original, parent);
            entity = ConvertObject(obj as GameObject, world);
            return obj;
        }

        public static T InstantiateAndCreateEntity<T>(T original, EcsWorld world) where T : Object
        {
            T obj = Object.Instantiate(original);
            ConvertObject(obj as GameObject, world);
            return obj;
        }

        internal static int ConvertContainer(ComponentsContainer container, EcsWorld world)
        {
            var destroyAfterConversion = container.DestroyAfterConversion;
            var entity = world.NewEntity();
            var packedEntity = world.PackEntityWithWorld(entity);

            foreach (var converter in container.Converters)
            {
                converter.Convert(packedEntity);

                if (destroyAfterConversion)
                {
                    Object.Destroy(converter);
                }
            }

            if (destroyAfterConversion)
            {
                Object.Destroy(container.gameObject);
            }

            return entity;
        }

        public static int CreateEntity(ComponentsContainer componentsContainer, Transform transform, EcsWorld world) =>
            ConvertContainer(componentsContainer, world);

        public static int ConvertObject(GameObject obj, EcsWorld world)
        {
            var container = obj.GetComponentInChildren<ComponentsContainer>();
#if DEBUG
            if (!container)
            {
                throw new Exception("You can not instantiate and create entity without components container");
            }
#endif

            return ConvertContainer(container, world);
        }
    }
}