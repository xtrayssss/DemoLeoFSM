using System;
using Leopotam.EcsLite.Packages.ECS.src;

namespace Components.Owners
{
    [Serializable]
    public struct OwnerComponent
    {
        public EcsPackedEntityWithWorld Value;
    }
}