using CodeBase.Components;
using CodeBase.Components.ScorePoint;
using CodeBase.Infrastructure.Services.Assets;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetLoader _assetLoader;
        private readonly ICoroutineRunner _coroutineRunner;
        private ScoreCounter _scoreCounter;

        public GameFactory(IAssetLoader assetLoader, ICoroutineRunner coroutineRunner)
        {
            _assetLoader = assetLoader;
            _coroutineRunner = coroutineRunner;
        }
    
        public GameObject CreatePlayer(Vector3 at) => 
            _assetLoader.Instantiate(AssetPaths.PlayerPrefabPath, at);

        public void CreateObstaclesSpawner(Vector3 at) => 
            _assetLoader.Instantiate(AssetPaths.ObstaclesSpawner, at);

        public ScoreCounter CreateHud() => 
            _scoreCounter = _assetLoader.Instantiate<ScoreCounter>(AssetPaths.Hud);

        public void CreatePointSpawner(Vector3 at)
        {
            PointSpawner spawner = _assetLoader.Instantiate<PointSpawner>(AssetPaths.PointSpawner, at);
            spawner.Construct(_scoreCounter);
        }
    }
}