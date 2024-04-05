using Leopotam.Ecs;
using UnityEngine;


sealed class PlayerJumpSendEventSystem : IEcsRunSystem
{
    private readonly EcsFilter<JumpComponent> playerFilter = null;
    public void Run()
    {
        if (!Input.GetKeyDown(KeyCode.Space)) return;

        foreach (var i in playerFilter)
        {
            ref var entity = ref playerFilter.GetEntity(i);
            entity.Get<JumpEvent>();
        }
    }
}
