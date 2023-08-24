using UnityEngine;

namespace CodeBase.Infrastructure.Services.Assets
{
    public interface IAssetLoader : IService
    {
        TComponent Instantiate<TComponent>(string path) where TComponent : MonoBehaviour;
        TComponent Instantiate<TComponent>(string path, Vector3 at) where TComponent : MonoBehaviour;
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Vector3 at);
    }
}