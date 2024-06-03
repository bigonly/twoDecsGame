using Leopotam.Ecs;
using UnityEngine;


sealed class MovementSystem : IEcsRunSystem
{
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<Player, KeyboardComponent> movableFilter = null;
    public void Run()
    {
        foreach (var i in movableFilter)
        {
            ref var playerComponent = ref movableFilter.Get1(i);
            ref var directionComponent = ref movableFilter.Get2(i);

            ref var direction = ref directionComponent.direction;

            ref var rigidbody2D = ref playerComponent.rigidbody2D;
            ref var speed = ref playerComponent.speed;

            rigidbody2D.velocity = new Vector2(direction.x * speed, playerComponent.velocity.y);
            rigidbody2D.AddForce(new Vector2(0, playerComponent.velocity.y));
        }
    }
}
