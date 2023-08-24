using System.Collections;
using UnityEngine;

namespace CodeBase.Components
{
    public class Curtain : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _hideSpeed = .1f;

        private void Awake()
        {
            gameObject.SetActive(false);
            DontDestroyOnLoad(this);
        }

        public void Show() => 
            ShowCanvas();

        public void Hide() => 
            StartCoroutine(HideCanvas());

        private IEnumerator HideCanvas()
        {
            while (_canvasGroup.alpha > 0)
            {
                _canvasGroup.alpha -= _hideSpeed;
                yield return new WaitForSeconds(.1f);
            }
            gameObject.SetActive(false);
        }

        private void ShowCanvas()
        {
            gameObject.SetActive(true);
            _canvasGroup.alpha = 1;
        }
    }
}