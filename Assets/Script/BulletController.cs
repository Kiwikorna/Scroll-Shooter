using System;
using AttackComponent;
using Bullet.Data;
using UnityEngine;

namespace Bullet.BulletController
{
    public class BulletController : MonoBehaviour
    {
        [SerializeField] private BulletSO attackProperties;
        
        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector2.up * (attackProperties.speed * Time.deltaTime));
        }
    
        public bool DistanceToDestroyBullet() => Mathf.Abs(transform.localPosition.y - attackProperties.range) <= 0.3f;
        public GameObject GetBulletPrefab() => attackProperties.spawnPrefabForAttack;
    }

    
}
