using Source.Infrastructure.Factories;
using Source.Logic.Invaders;
using Source.Logic.Ship;

namespace Source.Infrastructure
{
    public class LevelConfig
    {
        public LevelConfig(ShipHealth ship, InvaderContainer invaderContainer, IGameFactory gameFactory)
        {
            Ship = ship;
            InvaderContainer = invaderContainer;
            GameFactory = gameFactory;
        }

        public ShipHealth Ship { get; }
        public InvaderContainer InvaderContainer { get; }
        public IGameFactory GameFactory { get; }
    }
}