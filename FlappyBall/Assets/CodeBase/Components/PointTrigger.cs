using System;
using UnityEngine;

namespace CodeBase.Components
{
    public class PointTrigger : MonoBehaviour
    {
        private const string Player = "Player";
        public Action OnCollide { get; set; }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.CompareTag(Player))
                OnCollide?.Invoke();
        }
    }
}