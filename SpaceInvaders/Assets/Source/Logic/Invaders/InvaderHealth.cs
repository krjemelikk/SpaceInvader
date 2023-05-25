using UnityEngine;
using System;

namespace Source.Logic.Invaders
{
    public class InvaderHealth : MonoBehaviour, IHealth
    {
        public int Hp { get; set; }
        public event Action OnHealthChange;

        public void TakeDamage(int damage)
        {
            if (Hp <= 0)
                return;

            Hp -= damage;
            OnHealthChange?.Invoke();
        }
    }
}