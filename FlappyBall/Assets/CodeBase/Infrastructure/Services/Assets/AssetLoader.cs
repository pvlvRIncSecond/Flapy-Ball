using Unity.Mathematics;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Assets
{
    public class AssetLoader : IAssetLoader
    {
        public TComponent Instantiate<TComponent>(string path) where TComponent : MonoBehaviour
        {
            TComponent monoBehaviour = Resources.Load<TComponent>(path);
            return Object.Instantiate(monoBehaviour);
        }

        public TComponent Instantiate<TComponent>(string path, Vector3 at) where TComponent : MonoBehaviour
        {
            TComponent monoBehaviour = Resources.Load<TComponent>(path);
            return Object.Instantiate(monoBehaviour, at, quaternion.identity);
        }
        
        public GameObject Instantiate(string path, Vector3 at)
        {
            GameObject gameObject = Resources.Load<GameObject>(path);
            return Object.Instantiate(gameObject, at, Quaternion.identity);
        }

        public GameObject Instantiate(string path)
        {
            GameObject gameObject = Resources.Load<GameObject>(path);
            return Object.Instantiate(gameObject);
        }
    }
}