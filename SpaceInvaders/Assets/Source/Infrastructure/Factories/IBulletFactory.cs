using Source.Enum;
using Source.Logic;
using UnityEngine;

namespace Source.Infrastructure.Factories
{
    public interface IBulletFactory
    {
        Bullet CreateBullet(BulletType bulletType, Vector3 at, int layer);
    }
}