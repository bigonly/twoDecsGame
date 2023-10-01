using Leopotam.Ecs;
using UnityEngine;
using System.Collections;

namespace NTC.Source.Code.Ecs
{
    sealed class GroundCheckSystem : IEcsRunSystem
    {
        private readonly EcsFilter<GroundCheckCircleComponent> groundFilter = null;
        public void Run()
        {
            foreach (var i in groundFilter)
            {
                ref var groundCheck = ref groundFilter.Get1(i);

                /**groundCheck.isGrounded =
                    Physics2D.OverlapCircle(groundCheck.groundCheckPosition.position, groundCheck.groundDistance,
                        groundCheck.groundMask);**/
                groundCheck.isGrounded =
                    Physics2D.OverlapBox(groundCheck.groundCheckPosition.position, 
                    new Vector2(groundCheck.boxLenght, groundCheck.boxHeight),
                    0, groundCheck.groundMask);
                
            }
        }
    }
}