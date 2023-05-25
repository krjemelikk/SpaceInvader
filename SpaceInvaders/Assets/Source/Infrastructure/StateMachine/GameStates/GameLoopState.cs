using Source.Infrastructure.Services.StaticData;
using Source.Infrastructure.StateMachine.States;
using Source.Logic.Invaders;
using Source.StaticData;
using UnityEngine;
using Zenject;

namespace Source.Infrastructure.StateMachine.GameStates
{
    public class GameLoopState : IConfigurableState<LevelConfig>, ITickable
    {
        private readonly IStateMachine _gameStateMachine;
        private readonly IStaticDataService _staticDataService;
        private LevelConfig _levelConfig;

        public GameLoopState(IStateMachine gameStateMachine, IStaticDataService staticDataService)
        {
            _gameStateMachine = gameStateMachine;
            _staticDataService = staticDataService;
        }

        public void Enter(LevelConfig levelConfig)
        {
            _levelConfig = levelConfig;
        }

        public void Tick()
        {
            if (InvadersAreOver())
                SpawnNewInvaders();

            if (ShipDestroyed())
                RestartLevel();
        }

        public void Exit()
        {
        }

        private void RestartLevel() =>
            _gameStateMachine.Enter<LoadLevelState, string>(SceneName.Main);

        private bool ShipDestroyed() =>
            _levelConfig.Ship.IsDead;

        private bool InvadersAreOver() =>
            _levelConfig.InvaderContainer.InvaderCount <= 0;

        private void SpawnNewInvaders()
        {
            var data = _staticDataService.ForLevel();
            ResetContainer(data);
            FillContainer(_levelConfig.InvaderContainer);
        }

        private void ResetContainer(LevelStaticData data)
        {
            ResetPosition();

            void ResetPosition()
            {
                _levelConfig.InvaderContainer.transform.position =
                    data.InvanderContainerInitialPoint + Vector3.down * _levelConfig.InvaderContainer.CountInColumn;
            }
        }

        private void FillContainer(InvaderContainer container)
        {
            var data = _staticDataService.ForInvaderContainer();

            for (int i = 0; i < container.CountInColumn; i++)
            for (int j = 0; j < container.CountInRow; j++)
                container.AddInvader(_levelConfig.GameFactory.CreateInvader(data.InvadersTypeInRow[i], container));
        }
    }
}