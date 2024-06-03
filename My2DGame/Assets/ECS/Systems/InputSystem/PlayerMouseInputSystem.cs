using Leopotam.Ecs;
using UnityEngine;


public class PlayerMouseInputSystem : IEcsRunSystem
{
    private EcsFilter<MouseComponent, HasWeapon> inputFilter;
    private EcsWorld ecsWorld;
    public void Run()
    {
        //Debug.Log("Input System Works Ран");
        foreach (var i in inputFilter)
        {
            ref var entity = ref inputFilter.GetEntity(i);
            ref var shootComponent = ref inputFilter.Get1(i);
            ref var hasWeapon = ref inputFilter.Get2(i);
            shootComponent.leftMouseButton = Input.GetMouseButton(0);
            //Debug.Log(shootComponent.leftMouseButton);
        }
    }
}
