using Vector2 = UnityEngine.Vector2;

namespace Infrastructure.Services.Input
{
    public class InputService : IInputService
    {
        public Vector2 MovementDirection => _heroActions.Game.Move.ReadValue<Vector2>();
        public bool IsJump => _heroActions.Game.Jump.WasPressedThisFrame();
        public bool IsMeleeAttack => _heroActions.Game.MeleeAttack.IsPressed();

        private readonly HeroActions _heroActions;

        public InputService()
        {
            _heroActions = new HeroActions();
            _heroActions.Enable();
        }
    }
}