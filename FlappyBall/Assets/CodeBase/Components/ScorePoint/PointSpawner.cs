using System.Collections;
using UnityEngine;

namespace CodeBase.Components.ScorePoint
{
    public class PointSpawner : MonoBehaviour
    {
        [SerializeField] private ScorePoint _pointPrefab;
        [SerializeField] private float _spawnCooldown = 5f;
        [SerializeField] private float _verticalSpawnRange = 4f;

        private Coroutine _spawnCoroutine;
        private ScoreCounter _scoreCounter;

        private void OnEnable() =>
            _spawnCoroutine = StartCoroutine(Spawn());

        private void OnDisable() =>
            StopCoroutine(_spawnCoroutine);

        public void Construct(ScoreCounter scoreCounter) =>
            _scoreCounter = scoreCounter;

        private IEnumerator Spawn()
        {
            while (true)
            {
                if (_scoreCounter == null)
                    yield return null;

                float y = Random.Range(-_verticalSpawnRange, _verticalSpawnRange);
                Vector3 position = new Vector3(transform.position.x, y, 0);

                ScorePoint point = Instantiate(_pointPrefab, position, Quaternion.identity);
                point.Construct(_scoreCounter);

                yield return new WaitForSeconds(_spawnCooldown);
            }
        }
    }
}