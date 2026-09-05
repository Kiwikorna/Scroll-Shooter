using System;
using AttackComponent;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private BulletSO attackProperties;

    // Update is called once per frame
    void Update()
    {
        if(DistanceToDestroyBullet())
            Destroy(gameObject);
        transform.Translate(Vector2.up * (attackProperties.speed * Time.deltaTime));
    }
    
    private bool DistanceToDestroyBullet() => Mathf.Abs(transform.localPosition.y - attackProperties.range) <= 0.3f;
    public GameObject GetBullet() => attackProperties.spawnPrefabForAttack;
}
