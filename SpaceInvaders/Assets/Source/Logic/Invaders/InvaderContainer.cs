using System.Collections.Generic;
using System.Linq;
using Source.Infrastructure.Services.Random;
using UnityEngine;
using Zenject;

namespace Source.Logic.Invaders
{
    public class InvaderContainer : MonoBehaviour
    {
        private IRandomService _randomService;
        private readonly List<Invader> _invaders = new();
        private readonly float _offset = 1f;


        [Inject]
        private void Construct(IRandomService randomService)
        {
            _randomService = randomService;
        }

        public int InvaderCount => _invaders.Count;
        public Invader InvaderOfRightBound { get; private set; }
        public Invader InvaderOfLeftBound { get; private set; }
        public int CountInRow { get; set; }
        public int CountInColumn { get; set; }

        public void AddInvader(Invader invader)
        {
            SetPosition(invader);
            _invaders.Add(invader);

            UpdateBounds();
        }

        public void RemoveInvader(Invader invader)
        {
            _invaders.Remove(invader);
            UpdateBounds();
        }

        public Invader RandomInvader() =>
            _invaders[_randomService.Next(0, _invaders.Count)];

        private void UpdateBounds()
        {
            if (InvaderCount <= 0)
                return;

            InvaderOfRightBound = _invaders
                .Aggregate((i1, i2) => i1.transform.position.x > i2.transform.position.x ? i1 : i2);

            InvaderOfLeftBound = _invaders
                .Aggregate((i1, i2) => i1.transform.position.x < i2.transform.position.x ? i1 : i2);
        }

        private void SetPosition(Invader invader)
        {
            var yPosition = _invaders.Count / CountInRow * _offset;
            var xPosition = (_invaders.Count) % CountInRow * _offset;
            invader.transform.position = transform.position + new Vector3(xPosition, yPosition, 0);
        }
    }
}