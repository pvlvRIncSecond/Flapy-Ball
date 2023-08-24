using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CodeBase.Components.Obstacle
{
    public class ObstacleSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _obstaclePrefab;
        [SerializeField] private float _spawnCooldown = 5f;
        [SerializeField] private float _spawnsForCountIncrease = 4;

        [Header("Spawn Configurations")] [SerializeField]
        private int _initalCount = 2;

        [SerializeField] private float _distance = 2f;
        [SerializeField] private float _horizontalSpawnRange = .5f;
        [SerializeField] private float _verticalSpawnRange = 5;

        private int _totalSpawns = 0;
        private Coroutine _spawnCoroutine;

        private void OnEnable() =>
            _spawnCoroutine = StartCoroutine(Spawn());

        private void OnDisable() =>
            StopCoroutine(_spawnCoroutine);

        private IEnumerator Spawn()
        {
            while (true)
            {
                for (int i = 0; i < _initalCount; i++)
                {
                    float x = transform.position.x +
                              i * (_distance + Random.Range(-_horizontalSpawnRange, _horizontalSpawnRange));
                    float y = Random.Range(-_verticalSpawnRange, _verticalSpawnRange);
                    Vector3 position = new Vector3(x, y, 0);

                    Instantiate(_obstaclePrefab, position, Quaternion.identity);
                }

                _totalSpawns += 1;

                if (_totalSpawns % _spawnsForCountIncrease == 0)
                    _initalCount += 1;

                yield return new WaitForSeconds(_spawnCooldown);
            }
        }
    }
}