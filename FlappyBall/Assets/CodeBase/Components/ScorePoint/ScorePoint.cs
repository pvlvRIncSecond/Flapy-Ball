using UnityEngine;

namespace CodeBase.Components.ScorePoint
{
    public class ScorePoint : MonoBehaviour
    {
        [SerializeField] private float _speed = 6f;
        [SerializeField] private PointTrigger _pointTrigger;
        private ScoreCounter _scoreCounter;

        private void OnEnable() => 
            _pointTrigger.OnCollide += AddScore;

        private void OnDisable() => 
            _pointTrigger.OnCollide -= AddScore;

        private void Update() => 
            transform.position -= Vector3.right * _speed * Time.deltaTime;

        public void Construct(ScoreCounter scoreCounter) => 
            _scoreCounter = scoreCounter;

        private void AddScore()
        {
            _scoreCounter.Score += 1;
            Destroy(gameObject);
        }
    }
}
