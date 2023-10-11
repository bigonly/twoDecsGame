using Leopotam.Ecs;
using UnityEngine;
using System.Collections;

namespace NTC.Source.Code.Ecs
{
    sealed class GroundCheckSystem : IEcsRunSystem
    {
        private readonly EcsFilter<GroundCheckBoxComponent> groundFilter = null;
        public void Run()
        {
            foreach (var i in groundFilter)
            {
                ref var groundCheckBoxComponent = ref groundFilter.Get1(i);

                groundCheckBoxComponent.isGrounded =
                    Physics2D.OverlapBox(groundCheckBoxComponent.groundCheckPosition.position, 
                    new Vector2(groundCheckBoxComponent.boxLenght, groundCheckBoxComponent.boxHeight),
                    0, groundCheckBoxComponent.groundMask);
                
            }
        }
    }
}