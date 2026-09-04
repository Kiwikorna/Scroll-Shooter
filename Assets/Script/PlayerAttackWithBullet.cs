using AttackForObject;
using UnityEngine;

namespace AttackComponent
{
    public class PlayerAttackWithBullet : MonoBehaviour, IAttackable
    {
        [SerializeField] private BulletController bulletController;
        [SerializeField] private Transform spawnPositionForAttackPrefab;
        
        /*public GameObject CreatePrefabForAttack()
        {
            
        }*/
        public void Attack()
        {
            var instance = bulletController.GetBullet();
            var position = spawnPositionForAttackPrefab.position;
            Instantiate(instance,position,Quaternion.identity);
        }
        public bool IsAttacking()
        {
            throw new System.NotImplementedException();
        }
    }
}

