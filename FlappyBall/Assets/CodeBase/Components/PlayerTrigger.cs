using System;
using UnityEngine;

namespace CodeBase.Components
{
    public class PlayerTrigger : MonoBehaviour
    {
        private const string ScoreTag = "Score";
        public Action OnCollide { get; set; }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.transform.CompareTag(ScoreTag))
                OnCollide?.Invoke();
        }
    }
}