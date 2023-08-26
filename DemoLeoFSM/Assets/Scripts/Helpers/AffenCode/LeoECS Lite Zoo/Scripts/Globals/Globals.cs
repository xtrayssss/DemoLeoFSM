using System;
using System.Collections.Generic;
using UnityEngine;

namespace Helpers.AffenCode.LeoECS_Lite_Zoo.Scripts.Globals
{
    public static class Globals
    {
        private static readonly Dictionary<Type, object> Objects = new Dictionary<Type, object>();

        public static void Add(object sharedData)
        {
            Objects.Add(sharedData.GetType(), sharedData);
        }

        public static void Remove(object sharedData)
        {
            Objects.Remove(sharedData.GetType());
        }

        public static void Remove<T>()
        {
            Objects.Remove(typeof(T));
        }

        public static bool Has<T>()
        {
            return Objects.ContainsKey(typeof(T));
        }

        public static T Get<T>()
        {
            return (T) Objects[typeof(T)];
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void ResetSharedData()
        {
            Objects.Clear();
        }
    }
}