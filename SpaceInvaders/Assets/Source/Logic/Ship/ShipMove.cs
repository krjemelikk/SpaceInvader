using Source.Infrastructure.Services.Input;
using Source.Infrastructure.Services.Screen;
using UnityEngine;
using Zenject;

namespace Source.Logic.Ship
{
    public class ShipMove : MonoBehaviour
    {
        private IInputService _inputService;
        private IScreenBounds _screenBounds;

        private Collider2D _collider2D;
        private Rigidbody2D _rigidbody2D;

        private Vector2 _movementVector;

        [Inject]
        private void Construct(IInputService inputService, IScreenBounds screenBounds)
        {
            _inputService = inputService;
            _screenBounds = screenBounds;
        }

        public float MoveSpeed { get; set; }

        private void Awake()
        {
            _collider2D = GetComponent<Collider2D>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _movementVector = Vector2.zero;

            if (Mathf.Abs(_inputService.HorizontalValue) >= Constants.Epsilon)
            {
                if (!CanMove())
                    return;

                _movementVector = new Vector2(_inputService.HorizontalValue, 0);
            }
        }

        private void FixedUpdate()
        {
            Move();
        }


        private void Move() =>
            _rigidbody2D.velocity = _movementVector * MoveSpeed * Time.fixedDeltaTime;

        private bool CanMove() =>
            _inputService.HorizontalValue > 0 && CanMoveRight() ||
            _inputService.HorizontalValue < 0 && CanMoveLeft();

        private bool CanMoveRight()
        {
            var rightBound = _collider2D.bounds.max.x;
            return rightBound <= _screenBounds.RightBounds;
        }

        private bool CanMoveLeft()
        {
            var leftBound = _collider2D.bounds.min.x;
            return leftBound >= _screenBounds.LeftBounds;
        }
    }
}