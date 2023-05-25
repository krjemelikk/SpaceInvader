using UnityEngine;

namespace Source.StaticData
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "StaticData/Level")]
    public class LevelStaticData : ScriptableObject
    {
        public Vector3 ShipInitialPoint;
        public Vector3 InvanderContainerInitialPoint;
    }
}