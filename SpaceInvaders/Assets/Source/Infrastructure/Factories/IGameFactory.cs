using Source.Enum;
using Source.Logic.Invaders;
using UnityEngine;

namespace Source.Infrastructure.Factories
{
    public interface IGameFactory
    {
        GameObject CreateShip(Vector3 at);
        InvaderContainer CreateInvaderContainer(Vector3 at);
        Invader CreateInvader(InvaderType invaderType, InvaderContainer container);
    }
}