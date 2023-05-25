namespace Source.Infrastructure.Services.Input
{
    public interface IInputService
    {
        float HorizontalValue { get; }
        bool AttackButtonIsUp { get; }
    }
}