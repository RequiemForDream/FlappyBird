using TMPro;
using UnityEngine;

namespace UI
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreCount;
        private ScoreCounter _scoreCounter;

        public void Initialize(ScoreCounter scoreCounter)
        {
            _scoreCounter = scoreCounter;
            _scoreCounter.OnScoreChanged += IncreaseScore;
        }

        private void IncreaseScore(int score)
        {
            _scoreCount.text = score.ToString();
        }
    }
}
