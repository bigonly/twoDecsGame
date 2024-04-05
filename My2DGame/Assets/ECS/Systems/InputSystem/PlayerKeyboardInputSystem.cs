using Leopotam.Ecs;
using UnityEngine;


public class PlayerKeyboardInputSystem : IEcsRunSystem
{
    private EcsFilter<DirectionComponent> directionFilter;
    private EcsWorld world;

    public void Run() 
    {
        foreach (var i in directionFilter)
        {
            ref var directionComponent = ref directionFilter.Get1(i);
            ref var direction = ref directionComponent.direction;

            direction.x = Input.GetAxis("Horizontal");
        }
    }
}
