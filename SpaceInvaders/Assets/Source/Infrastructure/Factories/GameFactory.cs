using Source.AssetManagement;
using Source.Enum;
using Source.Infrastructure.Services.StaticData;
using Source.Logic.Invaders;
using Source.Logic.Ship;
using UnityEngine;
using Zenject;

namespace Source.Infrastructure.Factories
{
    public class GameFactory : IGameFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _staticDataService;

        public GameFactory(
            IInstantiator instantiator,
            IAssetProvider assetProvider,
            IStaticDataService staticDataService)
        {
            _instantiator = instantiator;
            _assetProvider = assetProvider;
            _staticDataService = staticDataService;
        }

        public GameObject CreateShip(Vector3 at)
        {
            var prefab = _assetProvider.Load<GameObject>(AssetPath.ShipPrefab);
            var data = _staticDataService.ForShip();
            var instance = _instantiator.InstantiatePrefab(prefab, at, Quaternion.identity, null);

            var shipMove = instance.GetComponent<ShipMove>();
            shipMove.MoveSpeed = data.MoveSpeed;

            var shipAttack = instance.GetComponent<ShipAttack>();
            shipAttack.AttackCooldown = data.AttackCooldown;
            shipAttack.ShootForce = data.ShootForce;

            var shipHealth = instance.GetComponent<ShipHealth>();
            shipHealth.Hp = data.Hp;

            return instance;
        }

        public InvaderContainer CreateInvaderContainer(Vector3 at)
        {
            var prefab = _assetProvider.Load<GameObject>(AssetPath.InvaderContainerPrefab);
            var data = _staticDataService.ForInvaderContainer();
            var position = at + Vector3.down * data.InvadersInColumn;

            var instance = _instantiator.InstantiatePrefab(prefab, position, Quaternion.identity, null);

            var containerMove = instance.GetComponent<InvaderContainerMove>();
            containerMove.Step = data.Step;
            containerMove.TimeBetweenSteps = data.TimeBetweenSteps;

            var containerAttack = instance.GetComponent<InvaderContainerAttack>();
            containerAttack.AttackCooldown = data.AttackCooldown;

            var container = instance.GetComponent<InvaderContainer>();
            container.CountInRow = data.InvadersInRow;
            container.CountInColumn = data.InvadersInColumn;

            return container;
        }

        public Invader CreateInvader(InvaderType invaderType, InvaderContainer container)
        {
            var data = _staticDataService.ForInvader(invaderType);
            var instance = _instantiator.InstantiatePrefab(data.Prefab, container.transform);

            var invader = instance.GetComponent<Invader>();
            invader.BulletType = data.BulletType;
            invader.ScoreReward = data.ScoreReward;
            invader.ShootForce = data.ShootForce;
            invader.Container = container;

            var invaderHealth = instance.GetComponent<InvaderHealth>();
            invaderHealth.Hp = data.Hp;

            return invader;
        }
    }
}