using System;
using Leopotam.EcsLite;

namespace Components.Owners
{
    [Serializable]
    public struct OwnerComponent
    {
        public EcsPackedEntityWithWorld Value;
    }
}