using Source.Enum;
using UnityEngine;

namespace Source.StaticData
{
    [CreateAssetMenu(fileName = "InvaderData", menuName = "StaticData/Invader")]
    public class InvaderStaticData : ScriptableObject
    {
        public InvaderType InvaderType;
        public int Hp;
        public int ScoreReward;
        public BulletType BulletType;
        public float ShootForce;
        public GameObject Prefab;
    }
}