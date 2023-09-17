using Leopotam.Ecs;
using UnityEngine;

namespace NTC.Source.Code.Ecs
{
    sealed class PlayerInputSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<PlayerTag, DirectionComponent> directionFilter = null;
        private float moveX;
        private float moveY;
        public void Run() 
        {
            SetDirection();

            foreach (var i in directionFilter)
            {
                ref var directionComponent = ref directionFilter.Get2(i);
                ref var direction = ref directionComponent.direction;

                direction.x = moveX;
                direction.y = moveY;
            }
        }
        private void SetDirection()
        {
            moveX = Input.GetAxis("Horizontal");
            moveY = Input.GetAxis("Vertical");
        }
    }
}