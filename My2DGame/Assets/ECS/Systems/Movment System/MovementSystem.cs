﻿using Leopotam.Ecs;
using UnityEngine;

namespace NTC.Source.Code.Ecs
{
    sealed class MovementSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<MovableComponent, DirectionComponent> movableFilter = null;
        public void Run()
        {
            foreach (var i in movableFilter)
            {
                ref var movableComponent = ref movableFilter.Get1(i);
                ref var directionComponent = ref movableFilter.Get2(i);

                ref var direction = ref directionComponent.direction;

                ref var rigidbody2D = ref movableComponent.rigidbody2D;
                ref var speed = ref movableComponent.speed;
                ref var velocity = ref movableComponent.velocity;
                
                rigidbody2D.velocity = new Vector2(direction.x * speed, velocity.y);
                rigidbody2D.AddForce(new Vector2(0, velocity.y));
            }
        }
    }
}