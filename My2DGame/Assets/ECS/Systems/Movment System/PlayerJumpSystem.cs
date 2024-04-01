using Leopotam.Ecs;
using System;


sealed class PlayerJumpSystem : IEcsRunSystem
{
    private readonly EcsFilter<PlayerTag, JumpComponent, JumpEvent> jumpFilter = null;
    public void Run()
    {
        foreach (var i in jumpFilter)
        {
            ref var entity = ref jumpFilter.GetEntity(i);
            ref var jumpComponent = ref jumpFilter.Get2(i);

            ref var doubleJumpComponent = ref entity.Get<MultiJumpComponent>();
            ref var movable = ref entity.Get<MovableComponent>();
            ref var velocity = ref movable.velocity;

            if (doubleJumpComponent.jumpCount < 1) continue;
            velocity.y = MathF.Sqrt(jumpComponent.force * -2f * movable.gravity);
        }
    }
}
