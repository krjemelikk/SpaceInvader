using System.Collections.Generic;
using Source.Enum;
using UnityEngine;

namespace Source.StaticData
{
    [CreateAssetMenu(fileName = "InvaderContainerData", menuName = "StaticData/InvaderContainer")]
    public class InvaderContainerStaticData : ScriptableObject
    {
        [Range(1, 8)] public int InvadersInRow;

        [Range(1, 5)] public int InvadersInColumn;

        public List<InvaderType> InvadersTypeInRow = new();

        public float TimeBetweenSteps;
        public float Step;
        public float AttackCooldown;
    }
}