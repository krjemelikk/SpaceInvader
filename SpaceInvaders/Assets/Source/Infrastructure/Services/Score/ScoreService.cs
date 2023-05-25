using System;

namespace Source.Infrastructure.Services.Score
{
    public class ScoreService : IScoreService
    {
        private int _score;
        public event Action<int> OnScoreChanged;

        public void AddScore(int score)
        {
            _score += score;
            OnScoreChanged?.Invoke(_score);
        }
    }
}