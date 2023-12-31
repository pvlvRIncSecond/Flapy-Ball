using System;
using System.Collections;
using UnityEngine;

namespace CodeBase.Components.ScorePoint
{
    public class ScorePoint : MonoBehaviour
    {
        [SerializeField] private float _destroyTime = 10f;
        [SerializeField] private float _speed = 6f;
        [SerializeField] private PointTrigger _pointTrigger;
        [SerializeField] private Rigidbody2D _rigidbody;
        private ScoreCounter _scoreCounter;

        private void Start() => 
            StartCoroutine(DestroyPoint());

        private void OnEnable() => 
            _pointTrigger.OnCollide += AddScore;

        private void OnDisable() => 
            _pointTrigger.OnCollide -= AddScore;

        private void Update()
        {
            _rigidbody.velocity = Vector2.left * _speed + Vector2.up * _rigidbody.velocity.y;
        }


        public void Construct(ScoreCounter scoreCounter) => 
            _scoreCounter = scoreCounter;

        private IEnumerator DestroyPoint()
        {
            yield return new WaitForSeconds(_destroyTime);
            Destroy(gameObject);
        }
        
        private void AddScore()
        {
            _scoreCounter.Score += 1;
            Destroy(gameObject);
        }
    }
}
