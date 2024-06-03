using Leopotam.Ecs;
using UnityEngine;


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
                new Vector2(groundCheckBoxComponent.boxLenght_X, groundCheckBoxComponent.boxHeight_Y),
                0, groundCheckBoxComponent.groundMask);
        }
    }
}
