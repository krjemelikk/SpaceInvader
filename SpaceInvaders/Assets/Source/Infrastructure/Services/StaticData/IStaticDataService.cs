using Source.Enum;
using Source.StaticData;

namespace Source.Infrastructure.Services.StaticData
{
    public interface IStaticDataService
    {
        void LoadData();
        LevelStaticData ForLevel();
        ShipStaticData ForShip();
        InvaderContainerStaticData ForInvaderContainer();
        InvaderStaticData ForInvader(InvaderType invaderType);
        BulletStaticData ForBullet(BulletType bulletType);
    }
}