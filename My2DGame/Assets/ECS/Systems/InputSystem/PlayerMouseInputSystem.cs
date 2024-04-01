using Leopotam.Ecs;
using UnityEngine;


sealed class PlayerMouseInputSystem : IEcsRunSystem
{
    private readonly EcsFilter<MouseComponent, HasWeapon> inputFilter = null;
    public void Run()
    {
        //Debug.Log("Input System Works Ран");
        foreach (var i in inputFilter)
        {
            ref var entity = ref inputFilter.GetEntity(i);
            ref var shootComponent = ref inputFilter.Get1(i);
            //ref var hasWeapon = ref filter.Get1(i);
            //ref var shootComponent = ref entity.Get<PlayerInputData>();
            Debug.Log(shootComponent.leftMouseButton);
            shootComponent.leftMouseButton = Input.GetMouseButton(0);
        }
    }
}
