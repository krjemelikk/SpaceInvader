using Source.Enum;
using Source.Infrastructure.Factories;
using Source.Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace Source.Logic.Ship
{
    public class ShipAttack : MonoBehaviour
    {
        [SerializeField] private Transform bulletSpawnPoint;

        private IInputService _inputService;
        private IBulletFactory _bulletFactory;

        private float _cooldown;


        [Inject]
        private void Construct(IInputService inputService, IBulletFactory bulletFactory)
        {
            _inputService = inputService;
            _bulletFactory = bulletFactory;
        }

        public float AttackCooldown { get; set; }
        public float ShootForce { get; set; }


        private void Update()
        {
            UpdateCooldown();

            if (_inputService.AttackButtonIsUp && CanAttack())
            {
                Shoot();
                ResetCooldown();
            }
        }

        private void Shoot()
        {
            var bullet = _bulletFactory.CreateBullet(BulletType.Yellow, bulletSpawnPoint.position, gameObject.layer);
            bullet.Rigidbody2D.AddForce(Vector2.up * ShootForce);
        }

        private bool CanAttack() =>
            CooldownIsUp();

        private void UpdateCooldown()
        {
            if (!CooldownIsUp())
                _cooldown -= Time.deltaTime;
        }

        private bool CooldownIsUp() =>
            _cooldown <= 0;

        private void ResetCooldown() =>
            _cooldown = AttackCooldown;
    }
}