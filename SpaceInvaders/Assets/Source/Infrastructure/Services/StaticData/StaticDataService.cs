using System.Collections.Generic;
using System.Linq;
using Source.Enum;
using Source.StaticData;
using UnityEngine;

namespace Source.Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string InvaderContainerDataPath = "StaticData/InvaderContainerData";
        private const string ShipDataPath = "StaticData/ShipData";
        private const string InvadersDataPath = "StaticData/Invaders";
        private const string BulletDataPath = "StaticData/Bullets";
        private const string LevelDataPath = "StaticData/LevelData";

        private Dictionary<InvaderType, InvaderStaticData> _invaders;
        private Dictionary<BulletType, BulletStaticData> _bullets;

        public void LoadData()
        {
            LoadInvadersData();
            LoadBulletData();
        }

        public ShipStaticData ForShip() =>
            Resources.Load<ShipStaticData>(ShipDataPath);

        public InvaderContainerStaticData ForInvaderContainer() =>
            Resources.Load<InvaderContainerStaticData>(InvaderContainerDataPath);

        public LevelStaticData ForLevel() =>
            Resources.Load<LevelStaticData>(LevelDataPath);

        public InvaderStaticData ForInvader(InvaderType invaderType) =>
            _invaders.TryGetValue(invaderType, out var data) ? data : null;

        public BulletStaticData ForBullet(BulletType bulletType) =>
            _bullets.TryGetValue(bulletType, out var data) ? data : null;

        private void LoadInvadersData()
        {
            _invaders = Resources
                .LoadAll<InvaderStaticData>(InvadersDataPath)
                .ToDictionary(d => d.InvaderType, d => d);
        }

        private void LoadBulletData()
        {
            _bullets = Resources
                .LoadAll<BulletStaticData>(BulletDataPath)
                .ToDictionary(b => b.BulletType, b => b);
        }
    }
}