using CodeBase.Infrastructure.Services.Assets;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetLoader _assetLoader;
        private readonly ICoroutineRunner _coroutineRunner;

        public GameFactory(IAssetLoader assetLoader, ICoroutineRunner coroutineRunner)
        {
            _assetLoader = assetLoader;
            _coroutineRunner = coroutineRunner;
        }
    
        public GameObject CreatePlayer(Vector3 at) => 
            _assetLoader.Instantiate(AssetPaths.PlayerPrefabPath, at);

        public void CreatingObstaclesSpawner(Vector3 at) => 
            _assetLoader.Instantiate(AssetPaths.ObstaclesSpawner, at);

    }
}