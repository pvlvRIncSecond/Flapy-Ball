using CodeBase.Infrastructure.Services.Input;
using CodeBase.Infrastructure.Services.Locator;
using UnityEngine;

namespace CodeBase.Components.Player
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _forceMultiplier;
    
        private IInputService _inputService;

        private void Awake() => 
            _inputService = ServiceLocator.Container.Single<IInputService>();

        private void OnEnable() => 
            _rigidbody.simulated = true;

        private void OnDisable() => 
            _rigidbody.simulated = false;

        private void FixedUpdate()
        {
            if (_inputService.MoveUp)
                _rigidbody.velocity += (Vector2.up * _forceMultiplier);

            _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);

        }
    }
}