using CodeBase.Infrastructure.Scenes;
using CodeBase.Infrastructure.Services.Assets;
using CodeBase.Infrastructure.Services.Factory;
using CodeBase.Infrastructure.Services.Input;
using CodeBase.Infrastructure.Services.Locator;

namespace CodeBase.Infrastructure.StateMachine.States
{
    public class BootstrapState : IState
    {
        private const string Boot = "Boot";
        private const string Main = "Main";

        private readonly GameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly ServiceLocator _serviceLocator;
        private readonly ICoroutineRunner _coroutineRunner;

        public BootstrapState(GameStateMachine gameStateMachine, ISceneLoader sceneLoader, ServiceLocator serviceLocator, ICoroutineRunner coroutineRunner)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _serviceLocator = serviceLocator;
            _coroutineRunner = coroutineRunner;

            RegisterServices();
        }

        public void Enter() =>
            _sceneLoader.Load(Boot, OnLoad);

        private void OnLoad() =>
            _gameStateMachine.Enter<LoadLevelState, string>(Main);

        public void Exit()
        {
        }

        private void RegisterServices()
        {
            _serviceLocator.RegisterSingle<IGameStateMachine>(_gameStateMachine);
            _serviceLocator.RegisterSingle<ICoroutineRunner>(_coroutineRunner);
            _serviceLocator.RegisterSingle<IInputService>(new InputService());
            _serviceLocator.RegisterSingle<IAssetLoader>(new AssetLoader());
            _serviceLocator.RegisterSingle<IGameFactory>(new GameFactory(_serviceLocator.Single<IAssetLoader>(), _serviceLocator.Single<ICoroutineRunner>()));
        }
    }
}