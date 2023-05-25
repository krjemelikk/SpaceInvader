using System;

namespace Source.Infrastructure.Services.Score
{
    public interface IScoreService
    {
        event Action<int> OnScoreChanged;
        void AddScore(int score);
    }
}