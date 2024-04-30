using Leopotam.Ecs;
using UnityEngine;

public class EnemyFollowSystem : IEcsRunSystem
{
    private 
        EcsFilter<Enemy, Follow, AnimatorRef>.
        Exclude<BlockAttack> followingEnemies;
    private RuntimeData runtimeData;
    private EcsWorld ecsWorld;

    public void Run()
    {
        foreach (var i in followingEnemies)
        {
            ref var entity = ref followingEnemies.GetEntity(i);
            ref var enemy = ref followingEnemies.Get1(i);
            ref var follow = ref followingEnemies.Get2(i);
            ref var animatorRef = ref followingEnemies.Get3(i);

            if (!follow.target.IsAlive())
            {
                animatorRef.animator.SetBool("Running", false);
                entity.Del<Follow>();
                continue;
            }
            ref var transformRef = ref follow.target.Get<TransformRef>();
            var targetPos = transformRef.transform.position;
            
            RaycastHit2D hit =
            Physics2D.BoxCast(enemy.boxCollider2D.bounds.center + enemy.transform.right * enemy.attackDistance * enemy.transform.localScale.x * enemy.triggerDistance,
            new Vector3(enemy.boxCollider2D.bounds.size.x * enemy.attackDistance, enemy.boxCollider2D.bounds.size.y, enemy.boxCollider2D.bounds.size.z),
            0, Vector2.left, 0, enemy.playerLayerMask);

            Debug.Log(follow.nextAttackTime);
            if (hit)
            {
                //Debug.Log("Attack");
                follow.nextAttackTime = Time.time + enemy.attackInterval;
                Debug.Log(follow.nextAttackTime);
                animatorRef.animator.SetTrigger("Attack");
                ref var e = ref ecsWorld.NewEntity().Get<DamageEvent>();
                e.target = follow.target;
                e.value = enemy.damage;
                entity.Get<BlockAttack>().attackTime = enemy.attackInterval;
            }
        }
    }
}
