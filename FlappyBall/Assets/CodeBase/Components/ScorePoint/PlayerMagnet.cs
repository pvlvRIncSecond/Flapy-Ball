using UnityEngine;

namespace CodeBase.Components.ScorePoint
{
    public class PlayerMagnet : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _speed = 5f;
        private const string PlayerTag = "Player";

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag(PlayerTag))
            {
                var direction = (other.transform.position - _rigidbody.transform.position).normalized;
                _rigidbody.AddForce(direction * _speed);
            }
        }
    }
}
