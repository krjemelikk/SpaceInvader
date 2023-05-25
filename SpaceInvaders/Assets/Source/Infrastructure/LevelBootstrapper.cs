using Source.Infrastructure.Factories;
using Source.Infrastructure.Services.StaticData;
using Source.Infrastructure.StateMachine;
using Source.Infrastructure.StateMachine.GameStates;
using Source.Logic.Invaders;
using Source.Logic.Ship;
using Source.StaticData;
using Source.UI.Factory;
using UnityEngine;
using Zenject;

namespace Source.Infrastructure
{
    public class LevelBootstrapper : MonoBehaviour
    {
        private IStateMachine _gameStateMachine;
        private IGameFactory _gameFactory;
        private IUIFactory _uiFactory;
        private IStaticDataService _staticDataService;

        [Inject]
        private void Construct(
            IStateMachine gameStateMachine,
            IGameFactory gameFactory,
            IUIFactory uiFactory,
            IStaticDataService staticDataService)
        {
            _gameStateMachine = gameStateMachine;
            _gameFactory = gameFactory;
            _uiFactory = uiFactory;
            _staticDataService = staticDataService;
        }

        private void Start()
        {
            InitializeUI();

            var levelData = _staticDataService.ForLevel();
            var config = InitializeLevel(levelData);

            _gameStateMachine.Enter<GameLoopState, LevelConfig>(config);
        }

        private void InitializeUI()
        {
            _uiFactory.CreateUIRoot();
            _uiFactory.CreateHUD();
        }

        private LevelConfig InitializeLevel(LevelStaticData levelData)
        {
            var ship = InitializeShip(levelData).GetComponent<ShipHealth>();
            var container = InitializeInvaderContainer(levelData);

            return new LevelConfig(ship, container, _gameFactory);
        }

        private GameObject InitializeShip(LevelStaticData levelData) =>
            _gameFactory.CreateShip(levelData.ShipInitialPoint);

        private InvaderContainer InitializeInvaderContainer(LevelStaticData levelData)
        {
            var container = _gameFactory.CreateInvaderContainer(levelData.InvanderContainerInitialPoint);
            FillContainer(container);

            return container;
        }

        private void FillContainer(InvaderContainer container)
        {
            var data = _staticDataService.ForInvaderContainer();

            for (int i = 0; i < container.CountInColumn; i++)
            for (int j = 0; j < container.CountInRow; j++)
                container.AddInvader(_gameFactory.CreateInvader(data.InvadersTypeInRow[i], container));
        }
    }
}