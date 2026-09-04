using AttackComponent;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private BulletSO attackProperties;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * (attackProperties.speed * Time.deltaTime));
    }

    public GameObject GetBullet() => attackProperties.spawnPrefabForAttack;
}
