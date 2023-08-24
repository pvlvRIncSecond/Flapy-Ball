using System;
using System.Collections;
using UnityEngine;

namespace CodeBase.Components.Player
{
    public class Tail : MonoBehaviour
    {
        [SerializeField] private float _scaleSpeed = .1f;
        [SerializeField] private float _scaleCooldown = .1f;
        [SerializeField] private float _tailHorizontalSpeed = 1;

        private void Awake() =>
            StartCoroutine(Downscale());

        private IEnumerator Downscale()
        {
            while (transform.localScale.x > 0)
            {
                transform.localScale -= _scaleSpeed * Vector3.one;
                yield return new WaitForSeconds(_scaleCooldown);
            }

            Destroy(gameObject);
        }

        private void Update() => 
            transform.position -= Vector3.right * _tailHorizontalSpeed * Time.deltaTime;
    }
}