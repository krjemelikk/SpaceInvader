using Source.Infrastructure.Services.Screen;
using UnityEngine;
using Zenject;

namespace Source.Logic.Invaders
{
    public class InvaderContainerMove : MonoBehaviour
    {
        private InvaderContainer _invaderContainer;
        private IScreenBounds _screenBounds;

        private Vector3 _movementVector = Vector3.right;
        private float _cooldown;


        [Inject]
        private void Construct(IScreenBounds screenBounds)
        {
            _screenBounds = screenBounds;
        }

        public float TimeBetweenSteps { get; set; }
        public float Step { get; set; }


        private void Awake()
        {
            _invaderContainer = GetComponent<InvaderContainer>();
        }

        private void Update()
        {
            UpdateCooldown();
            if (CanMove())
            {
                if (OnBound())
                {
                    DoStep(Vector3.down * Step);
                    ChangeDirection();
                    ResetCooldown();
                    return;
                }

                DoStep(_movementVector * Step);
                ResetCooldown();
            }
        }

        private void DoStep(Vector3 direction) =>
            transform.position += direction;


        private bool CanMove() =>
            CooldownIsUp() && HaveInvaders();

        private bool OnBound() =>
            _movementVector == Vector3.right && OnRightBound() ||
            _movementVector == Vector3.left && OnLeftBound();

        private void ChangeDirection() =>
            _movementVector *= -1;

        private bool OnRightBound()
        {
            var rightBound = _invaderContainer.InvaderOfRightBound.Collider.bounds.max.x;
            return rightBound >= _screenBounds.RightBounds;
        }

        private bool OnLeftBound()
        {
            var leftBound = _invaderContainer.InvaderOfLeftBound.Collider.bounds.min.x;
            return leftBound <= _screenBounds.LeftBounds;
        }

        private bool CooldownIsUp() =>
            _cooldown <= 0;

        private void ResetCooldown() =>
            _cooldown = TimeBetweenSteps;

        private void UpdateCooldown()
        {
            if (!CooldownIsUp())
                _cooldown -= Time.deltaTime;
        }

        private bool HaveInvaders() =>
            _invaderContainer.InvaderCount > 0;
    }
}