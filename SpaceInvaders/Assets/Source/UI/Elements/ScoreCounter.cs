using Source.Infrastructure.Services.Score;
using TMPro;
using UnityEngine;
using Zenject;

namespace Source.UI.Elements
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;
        private IScoreService _scoreService;


        [Inject]
        private void Construct(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }

        private void OnEnable() =>
            _scoreService.OnScoreChanged += UpdateScore;

        private void OnDisable() =>
            _scoreService.OnScoreChanged -= UpdateScore;

        private void UpdateScore(int currentScore) =>
            _scoreText.text = currentScore.ToString();
    }
}