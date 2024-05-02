using Leopotam.Ecs;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    public EcsEntity entity;
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
        entity.Get<HasWeapon>().weapon.Get<Shoot>();
    }
}