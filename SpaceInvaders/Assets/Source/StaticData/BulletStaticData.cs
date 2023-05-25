using Source.Enum;
using UnityEngine;

namespace Source.StaticData
{
    [CreateAssetMenu(fileName = "BulletData", menuName = "StaticData/Bullet")]
    public class BulletStaticData : ScriptableObject
    {
        public BulletType BulletType;
        public float LifeTime;
        public int Damage;
        public GameObject Prefab;
    }
}