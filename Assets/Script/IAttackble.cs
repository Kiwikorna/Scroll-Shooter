using UnityEngine;

namespace AttackForObject
{
    public interface IAttackable
    {
        public void Attack();
        public bool IsAttacking();
    }
}

