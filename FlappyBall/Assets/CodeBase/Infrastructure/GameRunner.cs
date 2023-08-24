using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class GameRunner : MonoBehaviour
    {
        [SerializeField] private GameBootstrapper _gameBootstrapper;

        private void Awake()
        {
            GameBootstrapper[] bootstrappers = FindObjectsOfType<GameBootstrapper>();
            if (bootstrappers.Length < 1) 
                Instantiate(_gameBootstrapper);
        }
    }
}
