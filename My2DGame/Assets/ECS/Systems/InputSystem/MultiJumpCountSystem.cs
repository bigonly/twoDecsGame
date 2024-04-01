using Leopotam.Ecs;
using UnityEngine;


sealed class MultiJumpCountSystem : IEcsRunSystem
{
    private readonly EcsFilter<MultiJumpComponent, GroundCheckBoxComponent> doubleJumpFilter = null;
    public void Run()
    {
        foreach (var i in doubleJumpFilter)
        {
            ref var entity = ref doubleJumpFilter.GetEntity(i);
            ref var multiJumpComponent = ref doubleJumpFilter.Get1(i);
            ref var groundCheckBoxComponent = ref doubleJumpFilter.Get2(i);
                
            ref var jumpCount = ref multiJumpComponent.jumpCount;
            ref var isGrounded = ref groundCheckBoxComponent.isGrounded;

            if (Input.GetKeyDown(KeyCode.Space)) --jumpCount;
            if (isGrounded) entity.Get<MultiJumpComponent>().jumpCount = multiJumpComponent.saveJumpCount;
        }
    }
}
