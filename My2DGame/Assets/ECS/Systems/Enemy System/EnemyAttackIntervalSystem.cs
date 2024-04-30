using Leopotam.Ecs;
using UnityEngine;

public class EnemyAttackIntervalSystem : IEcsRunSystem
{
    private EcsFilter<BlockAttack> filter;
    public void Run()
    {
        foreach (var i in filter)
        {
            ref var entity = ref filter.GetEntity(i);
            ref var block = ref filter.Get1(i);

            block.attackTime -= Time.deltaTime;
            if (block.attackTime <= 0 )
            {
                entity.Del<BlockAttack>();
            }
        }
    }
}