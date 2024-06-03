using Leopotam.Ecs;
using UnityEngine;
public class PlayerHealthSystem : IEcsRunSystem
{
    private readonly EcsFilter<HealthEvent> healFilter;
    private UI ui;
    public void Run()
    {
        foreach (var i in healFilter)
        {

            ref var entity = ref healFilter.Get1(i);
            ref var healthComponent = ref entity.target.Get<HealthComponent>();

            healthComponent.currentHealth = entity.value;

            if (healthComponent.ecsEntity.Has<Player>())
            {
                ui.gameScreen.SetHealth(healthComponent.currentHealth);
            }

            Debug.Log("Collected");
            healFilter.GetEntity(i).Destroy();
        }
    }
}
