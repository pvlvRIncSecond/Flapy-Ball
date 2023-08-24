using CodeBase.Infrastructure.Services.Assets;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetLoader _assetLoader;

        public GameFactory(IAssetLoader assetLoader) => 
            _assetLoader = assetLoader;

        public GameObject CreatePlayer(Vector3 at) => 
            _assetLoader.Instantiate(AssetPaths.PlayerPrefabPath, at);
    }
}