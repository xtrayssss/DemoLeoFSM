using System;
using UnityEngine;

namespace Components.Buffers
{
    [Serializable]
    public struct HitBuffer
    {
        public Collider2D[] value;
    }
}