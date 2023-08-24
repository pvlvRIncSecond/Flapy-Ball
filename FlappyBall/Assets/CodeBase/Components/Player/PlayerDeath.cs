using CodeBase.Infrastructure.Services.Locator;
using CodeBase.Infrastructure.StateMachine;
using CodeBase.Infrastructure.StateMachine.States;
using UnityEngine;

namespace CodeBase.Components.Player
{
    public class PlayerDeath: MonoBehaviour
    {
       [SerializeField] private PlayerTrigger playerTrigger;
    
        private const string Main = "Main";
    
        private IGameStateMachine _gameStateMachine;

        private void Awake() => 
            _gameStateMachine = ServiceLocator.Container.Single<IGameStateMachine>();

        private void OnEnable() => 
            playerTrigger.OnCollide += Death;

        private void OnDisable() => 
            playerTrigger.OnCollide -= Death;


        private void Death() => 
            _gameStateMachine.Enter<BootstrapState>();
    }
}
