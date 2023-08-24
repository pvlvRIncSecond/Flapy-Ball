using CodeBase.Infrastructure.Scenes;

namespace CodeBase.Infrastructure.StateMachine.States
{
    public class BootstrapState : IState
    {
        private const string Boot = "Boot";
        private const string Main = "Main";

        private readonly GameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;

        public BootstrapState(GameStateMachine gameStateMachine, ISceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter() =>
            _sceneLoader.Load(Boot, OnLoad);

        private void OnLoad() =>
            _gameStateMachine.Enter<LoadLevelState, string>(Main);

        public void Exit()
        {
        }
    }
}