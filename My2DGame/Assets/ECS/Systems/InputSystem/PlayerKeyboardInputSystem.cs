using Leopotam.Ecs;
using UnityEngine;


public class PlayerKeyboardInputSystem : IEcsRunSystem
{
    private EcsFilter<KeyboardComponent, HasWeapon> filter;
    private EcsWorld world;

    public void Run()
    {
        foreach (var i in filter)
        {
            ref var directionComponent = ref filter.Get1(i);
            ref var hasWeapon = ref filter.Get2(i);
            ref var direction = ref directionComponent.direction;

            direction.x = Input.GetAxis("Horizontal");
            if (Input.GetKeyDown(KeyCode.R))
            {
                ref var weapon = ref hasWeapon.weapon.Get<Weapon>();
                if (weapon.currentInMagazine < weapon.maxInMagazine)
                {
                    ref var entity = ref filter.GetEntity(i);
                    entity.Get<TryReload>();
                }
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                world.NewEntity().Get<PauseEvent>();
            }
        }
    }
}