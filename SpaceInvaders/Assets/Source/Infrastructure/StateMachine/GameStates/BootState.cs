using Source.Infrastructure.Services.StaticData;
using Source.Infrastructure.StateMachine.States;

namespace Source.Infrastructure.StateMachine.GameStates
{
    public class BootState : IState
    {
        private readonly IStateMachine _gameStateMachine;
        private readonly IStaticDataService _staticDataService;

        public BootState(IStateMachine gameStateMachine, IStaticDataService staticDataService)
        {
            _gameStateMachine = gameStateMachine;
            _staticDataService = staticDataService;
        }

        public void Enter()
        {
            _staticDataService.LoadData();

            _gameStateMachine.Enter<LoadLevelState, string>(SceneName.Main);
        }

        public void Exit()
        {
        }
    }
}