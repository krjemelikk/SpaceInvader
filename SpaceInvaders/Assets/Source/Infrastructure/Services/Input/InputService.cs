using UnityEngine;

namespace Source.Infrastructure.Services.Input
{
    public class InputService : IInputService
    {
        public const string Horizontal = "Horizontal";

        public float HorizontalValue =>
            UnityEngine.Input.GetAxisRaw(Horizontal);

        public bool AttackButtonIsUp =>
            UnityEngine.Input.GetKey(KeyCode.Space);
    }
}