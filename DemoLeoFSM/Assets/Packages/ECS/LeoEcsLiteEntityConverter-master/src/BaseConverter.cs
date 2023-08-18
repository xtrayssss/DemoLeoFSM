using Leopotam.EcsLite.Packages.ECS.src;
using UnityEngine;

namespace Packages.ECS.src
{
    [RequireComponent(typeof(ComponentsContainer))]
    public abstract class BaseConverter : MonoBehaviour
    {
        public abstract void Convert(EcsPackedEntityWithWorld entityWithWorld);
    }
}