using Source.Infrastructure.Factories;
using UnityEngine;
using Zenject;

namespace Source.Logic.Invaders
{
    public class InvaderContainerAttack : MonoBehaviour
    {
        private InvaderContainer _invaderContainer;
        private IBulletFactory _bulletFactory;

        private float _cooldown;

        [Inject]
        private void Construct(IBulletFactory bulletFactory)
        {
            _bulletFactory = bulletFactory;
        }

        public float AttackCooldown { get; set; }

        private void Awake()
        {
            _invaderContainer = GetComponent<InvaderContainer>();
        }

        private void Update()
        {
            UpdateCooldown();

            if (CanAttack())
            {
                Attack();
                ResetCooldown();
            }
        }

        private void Attack()
        {
            var invader = _invaderContainer.RandomInvader();

            var bullet = _bulletFactory.CreateBullet(
                invader.BulletType,
                invader.transform.position,
                invader.gameObject.layer);


            bullet.Rigidbody2D.AddForce(Vector2.down * invader.ShootForce);
        }

        private bool CanAttack() =>
            CooldownIsUp() && HasInvader();

        private void UpdateCooldown()
        {
            if (!CooldownIsUp())
                _cooldown -= Time.deltaTime;
        }

        private bool CooldownIsUp() =>
            _cooldown <= 0;

        private bool HasInvader() =>
            _invaderContainer.InvaderCount > 0;

        private void ResetCooldown() =>
            _cooldown = AttackCooldown;
    }
}