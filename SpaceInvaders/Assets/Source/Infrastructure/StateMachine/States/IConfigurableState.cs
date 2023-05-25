namespace Source.Infrastructure.StateMachine.States
{
    public interface IConfigurableState<in TConfig> : IExitableState
    {
        void Enter(TConfig config);
    }
}