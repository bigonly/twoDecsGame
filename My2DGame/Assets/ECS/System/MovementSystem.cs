using Leopotam.Ecs;
using UnityEngine;

namespace NTC.Source.Code.Ecs
{
    sealed class MovementSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<ModelComponent, MovableComponent, DirectionComponent> movableFilter = null;
        public void Run()
        {
            foreach (var i in movableFilter)
            {
                ref var modelComponent = ref movableFilter.Get1(i);
                ref var movableComponent = ref movableFilter.Get2(i);
                ref var directionComponent = ref movableFilter.Get3(i);

                ref var direction = ref directionComponent.direction;
                ref var transform = ref modelComponent.transform;

                ref var rigidbody2D = ref movableComponent.rigidbody2D;
                ref var speed = ref movableComponent.speed;
                ref var gravity = ref movableComponent.gravity;

                rigidbody2D.velocity = new Vector2(direction.x * speed, 0);
            }
        }
    }
}