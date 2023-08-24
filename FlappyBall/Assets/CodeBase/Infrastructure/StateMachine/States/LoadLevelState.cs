using CodeBase.Infrastructure.Scenes;
using CodeBase.Infrastructure.Services.Factory;
using UnityEngine;

namespace CodeBase.Infrastructure.StateMachine.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private const string InitialPoint = "InitialPoint";
        
        private readonly GameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;

        public LoadLevelState(GameStateMachine gameStateMachine, ISceneLoader sceneLoader, IGameFactory gameFactory)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
        }

        public void Enter(string sceneName) => 
            _sceneLoader.Load(sceneName, OnLoad);


        public void Exit()
        {
        }

        private void OnLoad()
        {
            GameObject playerPoint = GameObject.FindWithTag(InitialPoint);
            _gameFactory.CreatePlayer(playerPoint.transform.position);
        }
    }
}