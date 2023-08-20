using UnityEngine;

namespace Infrastructure.Services.Input
{
    public interface IInputService
    {
        public Vector2 MovementDirection { get; }
        public bool IsJump { get; }
        public bool IsMeleeAttack { get; }
    }
}