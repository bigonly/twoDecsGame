using Leopotam.Ecs;
using UnityEngine;

namespace NTC.Source.Code.Ecs
{
    sealed class DoubleJumpCountSystem : IEcsRunSystem
    {
        private readonly EcsFilter<DoubleJumpComponent, GroundCheckCircleComponent> doubleJumpFilter = null;
        public void Run()
        {
            foreach (var i in doubleJumpFilter)
            {
                ref var entity = ref doubleJumpFilter.GetEntity(i);
                ref var doubleJumpComponent = ref doubleJumpFilter.Get1(i);
                ref var groundCheckCircleComponent = ref doubleJumpFilter.Get2(i);
                
                ref var jumpCount = ref doubleJumpComponent.jumpCount;
                ref var isGrounded = ref groundCheckCircleComponent.isGrounded;

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    jumpCount --;
                    Debug.Log(jumpCount);
                }
                if (jumpCount < 0 & isGrounded) entity.Get<DoubleJumpComponent>().jumpCount = 2;
            }
        }
    }
}