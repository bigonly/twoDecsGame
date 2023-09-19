using Leopotam.Ecs;
using System;
using UnityEngine;

namespace NTC.Source.Code.Ecs
{
    sealed class PlayerJumpSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, GroundCheckCircleComponent, JumpComponent, JumpEvent> jumpFilter = null;
        public void Run()
        {
            foreach (var i in jumpFilter)
            {
                ref var entity = ref jumpFilter.GetEntity(i);
                ref var groundCheck = ref jumpFilter.Get2(i);
                ref var jumpComponent = ref jumpFilter.Get3(i);
                ref var movable = ref entity.Get<MovableComponent>();
                ref var velocity = ref movable.velocity;

                if (!groundCheck.isGrounded) continue;

                velocity.y = MathF.Sqrt(jumpComponent.force * -2f * 
                    (Physics2D.gravity.y * movable.rigidbody2D.gravityScale));
                //MathF.Sqrt(
                Debug.Log("Jump Force  * Physics2D.gravity.y : " + MathF.Sqrt(jumpComponent.force * Physics2D.gravity.y)); // - не число
                Debug.Log("Jump Force  * movable.gravity : " + MathF.Sqrt(jumpComponent.force * movable.gravity)); // - не число
                Debug.Log("Physics2D.gravity.y * Jump Force : " + MathF.Sqrt(Physics2D.gravity.y * jumpComponent.force)); // - не число
                Debug.Log("Physics2D.gravity.y * movable.gravity : " + MathF.Sqrt(Physics2D.gravity.y * movable.gravity));// - 16,27483
                Debug.Log("movable.gravity * Jump Force : " + MathF.Sqrt(movable.gravity * jumpComponent.force)); // - не число
                Debug.Log("movable.gravity * Physics2D.gravity.y : " + MathF.Sqrt(movable.gravity * Physics2D.gravity.y)); // - 16,27483
                // Nan --
                Debug.Log(" calculation with : MathF.Sqrt() " + MathF.Sqrt(jumpComponent.force * -2f * (Physics2D.gravity.y * movable.rigidbody2D.gravityScale)));
                Debug.Log(" calculation : " + (jumpComponent.force * -2f * (Physics2D.gravity.y * movable.gravity)) * (-1f));
                // Nan -- Debug.Log(velocity.y);
                //Debug.Log(movable.gravity);
            }
        }
    }
}