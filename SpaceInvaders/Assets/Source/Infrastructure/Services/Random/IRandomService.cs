namespace Source.Infrastructure.Services.Random
{
    public interface IRandomService
    {
        int Next(int min, int max);
    }
}