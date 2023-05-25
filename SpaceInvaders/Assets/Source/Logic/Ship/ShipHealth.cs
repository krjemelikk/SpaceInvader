using UnityEngine;
using System;

namespace Source.Logic.Ship
{
    public class ShipHealth : MonoBehaviour, IHealth
    {
        public int Hp { get; set; }
        public bool IsDead { get; private set; }

        public event Action OnHealthChange;

        private void OnEnable() =>
            OnHealthChange += Die;

        private void OnDisable() =>
            OnHealthChange -= Die;

        public void TakeDamage(int damage)
        {
            if (Hp <= 0)
                return;

            Hp -= damage;
            OnHealthChange?.Invoke();
        }

        private void Die()
        {
            if (Hp > 0)
                return;

            IsDead = true;
            gameObject.SetActive(false);
        }
    }
}