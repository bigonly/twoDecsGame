using Leopotam.Ecs;
using UnityEngine;

namespace NTC.Source.Code.Ecs
{
    sealed class GroundCheckSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, GroundCheckCircleComponent> groundFilter = null;
        public void Run()
        {
            foreach (var i in groundFilter)
            {
                ref var groundCheck = ref groundFilter.Get2(i);

                groundCheck.isGrounded =
                    Physics2D.OverlapCircle(groundCheck.groundCheckCircle.position, groundCheck.groundDistance,
                        groundCheck.groundMask);
            }//groundCheck.groundCheckCircle.position
        }
    }
}