using CodeBase.Components;
using CodeBase.Infrastructure.Scenes;
using CodeBase.Infrastructure.StateMachine.States;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private Curtain _curtainPrefab;
        
        void Awake()
        {
            var curtain = Instantiate(_curtainPrefab);
            
            var game = new Game(new SceneLoader(this, curtain));
            game.StateMachine.Enter<BootstrapState>();
            
            DontDestroyOnLoad(this);
        }
    }
}
