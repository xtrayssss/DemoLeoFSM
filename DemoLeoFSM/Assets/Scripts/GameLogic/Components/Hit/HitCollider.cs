using System;
using UniRx;
using UnityEngine;

namespace GameLogic.Components.Hit
{
    [Serializable]
    public struct HitCollider
    {
        public Collider2D value;
    }
}