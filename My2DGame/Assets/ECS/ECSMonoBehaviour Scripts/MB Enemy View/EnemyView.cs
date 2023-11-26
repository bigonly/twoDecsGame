using Leopotam.Ecs;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    public float meleeAttackDistance;
    public float triggerDistance;
    public float meleeAttackInterval;
    public int startHealth;
    public int damage;
    public EcsEntity entity;
}
