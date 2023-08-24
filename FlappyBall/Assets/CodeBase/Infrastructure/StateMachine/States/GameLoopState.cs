using CodeBase.Infrastructure.Services.Factory;
using UnityEngine;

namespace CodeBase.Infrastructure.StateMachine.States
{
    public class GameLoopState : IState
    {
        private const string ObstaclesPoint = "ObstaclesPoint";
        private readonly GameStateMachine _gameStateMachine;
        private readonly IGameFactory _gameFactory;

        public GameLoopState(GameStateMachine gameStateMachine, IGameFactory gameFactory)
        {
            _gameStateMachine = gameStateMachine;
            _gameFactory = gameFactory;
        }

        public void Enter()
        {
            GameObject spawnPoint = GameObject.FindWithTag(ObstaclesPoint);
            _gameFactory.CreateObstaclesSpawner(spawnPoint.transform.position);
            _gameFactory.CreatePointSpawner(spawnPoint.transform.position);
        }

        public void Exit()
        {
        }
    }
}