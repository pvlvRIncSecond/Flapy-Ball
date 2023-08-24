using UnityEngine;
using Random = UnityEngine.Random;

namespace CodeBase.Components.Obstacle
{
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] private float _speed = 4f; 
        [SerializeField] private float _rotationSpeed = 3f; 
        [SerializeField] private float _amplitude = 1f;

        private int _direction;
        private float _randomRotationRange;

        private void Awake()
        {
            _direction = Random.value > .5f ? 1 : -1;
            _randomRotationRange = Random.value * _direction;
        }

        private void Update()
        {
            transform.position -= Vector3.right * _speed * Time.deltaTime;
            transform.position -= Vector3.up * _direction * _amplitude *  Mathf.Sin(Time.time) * Time.deltaTime;
            transform.Rotate(Vector3.forward, _rotationSpeed * Time.deltaTime * _randomRotationRange);
        }
    }
}
