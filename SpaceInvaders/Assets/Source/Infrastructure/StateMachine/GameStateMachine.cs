using System;
using System.Collections.Generic;
using Source.Infrastructure.StateMachine.Factory;
using Source.Infrastructure.StateMachine.GameStates;
using Source.Infrastructure.StateMachine.States;
using Zenject;

namespace Source.Infrastructure.StateMachine
{
    public class GameStateMachine : IStateMachine, ITickable, IInitializable
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private readonly IStateFactory _statesFactory;

        private IExitableState _activeState;
        private ITickable _tickableState;

        public GameStateMachine(IStateFactory statesFactory)
        {
            _statesFactory = statesFactory;
            _states = new Dictionary<Type, IExitableState>();
        }

        public void Initialize()
        {
            RegisterState<BootState>();
            RegisterState<LoadLevelState>();
            RegisterState<GameLoopState>();
        }

        public void Tick()
        {
            _tickableState?.Tick();
        }

        public void Enter<TState>() where TState : IState
        {
            var state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TConfig>(TConfig config) where TState : IConfigurableState<TConfig>
        {
            var state = ChangeState<TState>();
            state.Enter(config);
        }

        private TState ChangeState<TState>() where TState : IExitableState
        {
            var state = GetState<TState>();
            _activeState?.Exit();
            _activeState = state;
            _tickableState = state as ITickable;

            return state;
        }

        private TState GetState<TState>() where TState : IExitableState =>
            (TState) _states[typeof(TState)];

        private void RegisterState<TState>() where TState : IExitableState =>
            _states.Add(typeof(TState), _statesFactory.Create<TState>());
    }
}