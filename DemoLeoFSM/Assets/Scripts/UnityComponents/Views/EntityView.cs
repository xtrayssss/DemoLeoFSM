using Leopotam.EcsLite;
using UnityEngine;

namespace UnityComponents.Views
{
    public abstract class EntityView : MonoBehaviour
    {
        public abstract int Entity { get; protected set; }
        
        public abstract EcsWorld World { get; protected set; }

        public void Init(int entity, EcsWorld world)
        {
            Entity = entity;

            World = world;
        }
    }
}