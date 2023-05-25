using Source.Infrastructure.StateMachine.States;
using Zenject;

namespace Source.Infrastructure.StateMachine.Factory
{
    public class StateFactory : IStateFactory
    {
        private readonly IInstantiator _instantiator;

        public StateFactory(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public IExitableState Create<TState>() where TState : IExitableState =>
            _instantiator.Instantiate<TState>();
    }
}