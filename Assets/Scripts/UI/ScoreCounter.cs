using System;

namespace UI
{
    public class ScoreCounter
    {
        public event Action<int> OnScoreChanged;
        private int _score;

        public void AddScore(int scoreToAdd)
        {
            _score += scoreToAdd;
            OnScoreChanged?.Invoke(_score);  
        }
    }
}
