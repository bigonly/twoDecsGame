using Leopotam.Ecs;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    public EcsEntity entity;
    public Animator animator;
    public Transform transform;
    public float meleeAttackDistance;
    public float triggerDistance;
    public float meleeAttackInterval;
    public int startHealth;
    public float damage;
}