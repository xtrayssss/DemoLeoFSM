using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Leopotam.EcsLite;
using UnityEngine;

namespace Helpers.AffenCode.LeoECS_Lite_Zoo.Scripts.Injection
{
    public static class LeoEcsLiteInjector
    {
        private static readonly HashSet<object> InjectedObjects = new HashSet<object>();
        
        public static void AddInjection(object injectedObject)
        {
            InjectedObjects.Add(injectedObject);
        }

        public static void RemoveInjection(object injectedObject)
        {
            InjectedObjects.Remove(injectedObject);
        }

        public static IEcsSystems Inject(this IEcsSystems ecsSystems)
        {
            foreach (var injectedObject in InjectedObjects)
            {
                if (injectedObject != null)
                {
                    ecsSystems.Inject(injectedObject);
                }
            }

            ecsSystems.Inject(ecsSystems.GetWorld());

            return ecsSystems;
        }

        private static IEcsSystems Inject(this IEcsSystems ecsSystems, object injectedObject)
        {
            var allSystems = ecsSystems.GetAllSystems();

            foreach (var system in allSystems)
            {
                var systemType = system.GetType();
                var systemFields = systemType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                var injectedObjectType = injectedObject.GetType();
                var requiredField = systemFields.FirstOrDefault(x => x.FieldType == injectedObjectType);
                if (requiredField != null)
                {
                    requiredField.SetValue(system, injectedObject);
                }
            }
            
            return ecsSystems;
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void ResetInjections()
        {
            InjectedObjects.Clear();
        }
    }
}