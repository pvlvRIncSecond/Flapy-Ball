using UnityEngine;

namespace CodeBase.Infrastructure.Services.Input
{
    public class InputService : IInputService
    {
        public bool MoveUp => UnityEngine.Input.GetKey(KeyCode.Space) || UnityEngine.Input.GetKey(KeyCode.Mouse0);
    }
}