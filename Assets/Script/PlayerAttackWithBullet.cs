using System;
using AttackForObject;
using Bullet.BulletController;
using UnityEngine;

namespace AttackComponent
{
    public class PlayerAttackWithBullet : MonoBehaviour, IAttackable
    {
        [SerializeField] private BulletController bulletController;
        [SerializeField] private Transform spawnPositionForAttackPrefab;

        private PoolObject<BulletController> _bulletPool;


        public void Awake()
        {
            _bulletPool = new PoolObject<BulletController>(bulletController, spawnPositionForAttackPrefab);
        }

        public void Update()
        {
            if (_bulletPool.pool.Count > 0)
            {
                foreach (var bullet in _bulletPool.pool)
                {
                    if (bullet.DistanceToDestroyBullet())
                    {
                        _bulletPool.Release(bullet);
                    }
                }
            }
        }
        public void Attack()
        {
            var bullet = _bulletPool.GetOrActive();
            
            /*var bulletInstantiatedBefore = bulletController.GetBulletJPrefab();
            var position = spawnPositionForAttackPrefab.position;
            var bulletInstantiation = Instantiate(bulletInstantiatedBefore,position,Quaternion.identity);

            bulletInstantiation.transform.SetParent(spawnPositionForAttackPrefab);*/
        }
      
        public bool IsAttacking()
        {
            throw new System.NotImplementedException();
        }
    }
}

