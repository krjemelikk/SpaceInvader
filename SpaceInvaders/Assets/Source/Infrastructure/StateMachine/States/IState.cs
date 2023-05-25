namespace Source.Infrastructure.StateMachine.States
{
    public interface IState : IExitableState
    {
        void Enter();
    }
}