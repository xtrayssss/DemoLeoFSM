using System;
using UnityEngine;

namespace GameLogic.Components.Movement
{
    [Serializable]
    public struct MovementDirection
    {
        public Vector2 direction;
        public Vector2 movementVector;
    }
}