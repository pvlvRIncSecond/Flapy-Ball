using CodeBase.Components.Player;
using CodeBase.Infrastructure.Services.Input;
using CodeBase.Infrastructure.Services.Locator;
using CodeBase.Infrastructure.StateMachine;
using CodeBase.Infrastructure.StateMachine.States;
using UnityEngine;

public class LevelStarter : MonoBehaviour
{

    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private CircleTail _circleTail;
    
    private IGameStateMachine _gameStateMachine;
    private IInputService _inputService;

    private void Awake()
    {
        _inputService = ServiceLocator.Container.Single<IInputService>();
        _gameStateMachine = ServiceLocator.Container.Single<IGameStateMachine>();
    }

    private void Update()
    {
        if (_inputService.MoveUp)
        {
            _gameStateMachine.Enter<GameLoopState>();
            _playerMover.enabled = true;
            _circleTail.enabled = true;
            
            Destroy(gameObject);
        }
        
    }
}
