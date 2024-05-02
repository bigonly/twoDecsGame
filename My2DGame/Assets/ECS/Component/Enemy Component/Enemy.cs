using UnityEngine;

public struct Enemy
{
    public Animator animator;
    public Transform transform;
    public LayerMask playerLayerMask;
    public BoxCollider2D boxCollider2D;
    public EnemyPatrol enemyPatrol;
    public WeaponSettings weaponSettings;
    public float attackDistance;
    public float triggerDistance;
    public float attackInterval;
    public float damage;
    public bool rangedEnemy;
}
