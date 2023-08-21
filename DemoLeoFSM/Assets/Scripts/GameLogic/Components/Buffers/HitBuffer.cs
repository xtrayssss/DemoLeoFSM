using System;
using UnityEngine;

namespace GameLogic.Components.Buffers
{
    [Serializable]
    public struct HitBuffer
    {
        public Collider2D[] value;
    }
}