using System.Collections;
using UnityEngine;

namespace CodeBase.Components.Player
{
    public class CircleTail : MonoBehaviour
    {
        [SerializeField] private Tail _tailPrefab;
        [SerializeField] private float _spawnTailCooldown = .5f;

        private void Start() =>
            StartCoroutine(SpawnTails());

        private void OnDestroy() =>
            StopAllCoroutines();

        private IEnumerator SpawnTails()
        {
            while (true)
            {
                Instantiate(_tailPrefab, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(_spawnTailCooldown);
            }
        }
    }
}