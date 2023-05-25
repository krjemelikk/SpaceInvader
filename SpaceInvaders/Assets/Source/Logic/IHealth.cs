using System;

namespace Source.Logic
{
    public interface IHealth
    {
        int Hp { get; set; }
        event Action OnHealthChange;
        void TakeDamage(int damage);
    }
}