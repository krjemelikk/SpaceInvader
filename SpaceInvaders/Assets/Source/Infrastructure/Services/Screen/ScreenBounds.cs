using UnityEngine;

namespace Source.Infrastructure.Services.Screen
{
    public class ScreenBounds : IScreenBounds
    {
        private readonly Camera _camera;
        private readonly float _offset = 0.5f;

        public ScreenBounds(Camera mainCamera)
        {
            _camera = mainCamera;

            Initialize();
        }

        public float LeftBounds { get; private set; }
        public float RightBounds { get; private set; }

        private void Initialize()
        {
            CalculateBounds();
        }

        private void CalculateBounds()
        {
            LeftBounds = _camera.transform.position.x - _camera.orthographicSize * _camera.aspect + _offset;
            RightBounds = _camera.transform.position.x + _camera.orthographicSize * _camera.aspect - _offset;
        }
    }
}