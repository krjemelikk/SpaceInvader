using Source.Infrastructure.StateMachine;
using Source.Infrastructure.StateMachine.GameStates;
using UnityEngine;
using Zenject;

namespace Source.Infrastructure
{
    public class EntryPoint : MonoBehaviour
    {
        private IStateMachine _gameStateMachine;

        [Inject]
        private void Construct(IStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        private void Start()
        {
            _gameStateMachine.Enter<BootState>();
        }
    }
}