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
        // ReSharper disable Unity.PerformanceAnalysis
        public void Attack()
        {
            var bulletInstantiatedBefore = bulletController.GetBullet();
            var position = spawnPositionForAttackPrefab.position;
            var bulletInstantiation = Instantiate(bulletInstantiatedBefore,position,Quaternion.identity);
            
            bulletInstantiation.transform.SetParent(spawnPositionForAttackPrefab);
        }
        public bool IsAttacking()
        {
            throw new System.NotImplementedException();
        }
    }
}

