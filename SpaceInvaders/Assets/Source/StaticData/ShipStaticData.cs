using Source.Enum;
using UnityEngine;

namespace Source.StaticData
{
    [CreateAssetMenu(fileName = "ShipData", menuName = "StaticData/Ship")]
    public class ShipStaticData : ScriptableObject
    {
        public int Hp;
        public float MoveSpeed;
        public BulletType BulletType;
        public float AttackCooldown;
        public float ShootForce;
    }
}