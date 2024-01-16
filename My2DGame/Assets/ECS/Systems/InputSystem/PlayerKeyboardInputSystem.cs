using Leopotam.Ecs;
using UnityEngine;

namespace NTC.Source.Code.Ecs
{
    sealed class PlayerKeyboardInputSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<PlayerTag, DirectionComponent> directionFilter = null;
        private float moveX;

        public void Run() 
        {
            SetDirection();

            foreach (var i in directionFilter)
            {
                ref var directionComponent = ref directionFilter.Get2(i);
                ref var direction = ref directionComponent.direction;

                direction.x = moveX;
            }
        }
        private void SetDirection()
        {
            moveX = Input.GetAxis("Horizontal");
        }
    }
}