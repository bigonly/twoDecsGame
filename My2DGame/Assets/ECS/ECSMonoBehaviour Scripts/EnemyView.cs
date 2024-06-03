using Leopotam.Ecs;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    public GameObject[] sounds;
    public EcsEntity entity;
    public GameObject enemyPrefab;
    public Animator animator;
    public Transform transform;
    public LayerMask playerLayerMask;
    public BoxCollider2D boxCollider2D;
    [Header("Enemy Attack Parametrs")]
    public float attackDistance;
    public float triggerDistance;
    public float attackInterval;
    public int startHealth;
    public float damage;
    [Header("Enemy is Ranged Parametrs")]
    public bool rangedEnemy;
    public WeaponSettings weaponSettings;
    [Header("Enemy Patrol Path")]
    public EnemyPatrol enemyPatrol;

    public void Shoot()
    {
        int rand = Random.Range(0, sounds.Length);
        Instantiate(sounds[rand], transform.position, Quaternion.identity);
        entity.Get<HasWeapon>().weapon.Get<Shoot>();
    }
}