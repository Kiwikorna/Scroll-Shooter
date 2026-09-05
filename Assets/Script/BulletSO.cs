using UnityEngine;

[CreateAssetMenu(fileName = "AttackProperties", menuName = "SO/Player")]
public class BulletSO : ScriptableObject
{
    public GameObject spawnPrefabForAttack;
 
    public int damage; 
    public float speed;
    public float range;
    public float coolDown;
}
