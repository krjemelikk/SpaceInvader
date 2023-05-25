using Source.Enum;
using Source.Infrastructure.Services.Score;
using UnityEngine;
using Zenject;

namespace Source.Logic.Invaders
{
    public class Invader : MonoBehaviour
    {
        private InvaderHealth _health;
        private IScoreService _scoreService;

        [Inject]
        private void Construct(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }

        public Collider2D Collider { get; private set; }
        public InvaderContainer Container { get; set; }
        public BulletType BulletType { get; set; }
        public float ShootForce { get; set; }
        public int ScoreReward { get; set; }

        private void Awake()
        {
            Collider = GetComponent<Collider2D>();
            _health = GetComponent<InvaderHealth>();
        }

        private void OnEnable() =>
            _health.OnHealthChange += Die;

        private void OnDisable() =>
            _health.OnHealthChange -= Die;


        private void Die()
        {
            if (_health.Hp > 0)
                return;

            _scoreService.AddScore(ScoreReward);
            Container.RemoveInvader(this);
            Destroy(gameObject);
        }
    }
}