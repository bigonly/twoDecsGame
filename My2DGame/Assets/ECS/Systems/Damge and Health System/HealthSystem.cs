using Leopotam.Ecs;
using UnityEngine;

public class HealthSystem : IEcsRunSystem
{
    private EcsFilter<Bone> filter;
    private EcsWorld ecsWorld;
    private RuntimeData runtimeData;
    public void Run()
    {
        foreach (var i in filter)
        {

            ref var entity = ref filter.GetEntity(i);
            ref var bone = ref filter.Get1(i);

            //Debug.Log("Heal");

            Collider2D hit =
                Physics2D.OverlapBox(bone.boxCollider2D.bounds.center,
                new Vector2(bone.boxCollider2D.bounds.size.x, bone.boxCollider2D.bounds.size.y), 0, bone.LayerMask);

            if (hit)
            {
                //Debug.Log("player was heald");
                ref var e = ref ecsWorld.NewEntity().Get<HealthEvent>();
                e.target = runtimeData.playerEntity;
                e.value = 100f;
                entity.Destroy();
            }

        }
    }
}