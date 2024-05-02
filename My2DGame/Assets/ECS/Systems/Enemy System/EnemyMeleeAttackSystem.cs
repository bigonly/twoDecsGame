using Leopotam.Ecs;
using UnityEditor;
using UnityEngine;

public class EnemyMeleeAttackSystem : IEcsRunSystem
{
    private 
        EcsFilter<Enemy, AnimatorRef, Idle>.
        Exclude<BlockAttack> calmEnemies;
    private RuntimeData runtimeData;
    private EcsWorld ecsWorld;
    public void Run()
    {
        foreach (var i in calmEnemies)
        {
            ref var enemy = ref calmEnemies.Get1(i);
            ref var animatorRef = ref calmEnemies.Get2(i);

            if (enemy.rangedEnemy) continue;
            RaycastHit2D hit =
            Physics2D.BoxCast(enemy.boxCollider2D.bounds.center + enemy.transform.right * enemy.attackDistance * enemy.transform.localScale.x * enemy.triggerDistance,
            new Vector3(enemy.boxCollider2D.bounds.size.x * enemy.attackDistance, enemy.boxCollider2D.bounds.size.y, enemy.boxCollider2D.bounds.size.z),
            0, Vector2.left, 0, enemy.playerLayerMask);

            if (hit)
            {
                ref var entity = ref calmEnemies.GetEntity(i);
                ref var follow = ref entity.Get<Follow>();
                follow.target = runtimeData.playerEntity;
                animatorRef.animator.SetTrigger("Attack");
                ref var e = ref ecsWorld.NewEntity().Get<DamageEvent>();
                e.target = follow.target;
                e.value = enemy.damage;
                entity.Get<BlockAttack>().attackTime = enemy.attackInterval;
                //animationRef.animator.SetBool("Running", true);
            }
            if (enemy.enemyPatrol != null)
            {
                enemy.enemyPatrol.enabled = !hit;
            }
        }
    }
}
