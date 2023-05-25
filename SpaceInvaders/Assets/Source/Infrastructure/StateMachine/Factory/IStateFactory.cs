using Source.Infrastructure.StateMachine.States;

namespace Source.Infrastructure.StateMachine.Factory
{
    public interface IStateFactory
    {
        IExitableState Create<TState>() where TState : IExitableState;
    }
}