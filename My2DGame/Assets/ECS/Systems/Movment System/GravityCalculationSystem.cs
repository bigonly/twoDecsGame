using Leopotam.Ecs;
using UnityEngine;


sealed class GravityCalculationSystem : IEcsRunSystem
{
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<PlayerTag, MovableComponent, GroundCheckBoxComponent> gravityFilter = null;
    public void Run()
    {
        foreach (var i in gravityFilter)
        {
            ref var movableComponent = ref gravityFilter.Get2(i);
            ref var groundCheckCircleComponent = ref gravityFilter.Get3(i);
                
            ref var velocity = ref movableComponent.velocity;
            ref var isGrounded = ref groundCheckCircleComponent.isGrounded;

            if (isGrounded && velocity.y < 0.0f)
            {
                velocity.y = -1.0f;
            }
            else
            {
                velocity.y += movableComponent.gravity * Time.deltaTime;
            }
        }
    }
}
