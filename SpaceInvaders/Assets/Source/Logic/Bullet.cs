using UnityEngine;

namespace Source.Logic
{
    public class Bullet : MonoBehaviour
    {
        private float _lifeTime;

        public Rigidbody2D Rigidbody2D { get; private set; }
        public float LifeTime { get; set; }
        public int Damage { get; set; }

        private void Awake()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            UpdateLifeTime();

            if (LifeTimeIsOver())
                Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<IHealth>(out var health))
            {
                health.TakeDamage(Damage);
                Destroy(gameObject);
            }

            if (other.TryGetComponent<Bullet>(out var bullet))
            {
                Destroy(gameObject);
            }
        }

        private bool LifeTimeIsOver() =>
            _lifeTime >= LifeTime;

        private void UpdateLifeTime() =>
            _lifeTime += Time.deltaTime;
    }
}