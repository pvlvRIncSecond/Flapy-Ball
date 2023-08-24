using UnityEngine;

namespace CodeBase.Components
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private TMPro.TextMeshProUGUI _scoreText;
    
        private int _score;

        private void Awake() => 
            Score = 0;

        public int Score
        {
            get => _score;
            set
            {
                _score = value;
                _scoreText.text = _score.ToString();
            }
        }
    }
}
