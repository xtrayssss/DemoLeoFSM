using System;
using Leopotam.EcsLite;

namespace GameLogic.Components.Owners
{
    [Serializable]
    public struct OwnerComponent
    {
        public EcsPackedEntityWithWorld Value;
    }
}