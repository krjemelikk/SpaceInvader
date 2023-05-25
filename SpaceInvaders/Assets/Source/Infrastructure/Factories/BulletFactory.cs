using Source.Enum;
using Source.Infrastructure.Services.StaticData;
using Source.Logic;
using UnityEngine;
using Zenject;

namespace Source.Infrastructure.Factories
{
    public class BulletFactory : IBulletFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IStaticDataService _staticDataService;

        public BulletFactory(
            IInstantiator instantiator,
            IStaticDataService staticDataService)
        {
            _instantiator = instantiator;
            _staticDataService = staticDataService;
        }

        public Bullet CreateBullet(BulletType bulletType, Vector3 at, int layer)
        {
            var data = _staticDataService.ForBullet(bulletType);
            var instance = _instantiator.InstantiatePrefab(data.Prefab, at, Quaternion.identity, null);

            instance.layer = layer;

            var bullet = instance.GetComponent<Bullet>();
            bullet.Damage = data.Damage;
            bullet.LifeTime = data.LifeTime;

            return bullet;
        }
    }
}