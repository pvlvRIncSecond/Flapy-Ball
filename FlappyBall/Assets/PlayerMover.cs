using CodeBase.Infrastructure.Services.Input;
using CodeBase.Infrastructure.Services.Locator;
using CodeBase.Infrastructure.StateMachine;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _forceMultiplier;
    
    private IInputService _inputService;

    private void Awake()
    {
        _inputService = ServiceLocator.Container.Single<IInputService>();
        ServiceLocator.Container.Single<IGameStateMachine>();
    }

    private void Update()
    {
        if (_inputService.MoveUp)
            _rigidbody.AddForce(Vector2.up * _forceMultiplier);
    }
}