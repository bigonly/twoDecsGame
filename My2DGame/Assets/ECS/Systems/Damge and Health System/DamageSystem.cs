using Leopotam.Ecs;
using UnityEngine;


public class DamageSystem : IEcsRunSystem
{
    private readonly EcsFilter<DamageEvent> damageFilter;
    public void Run()
    {
        foreach (var i in damageFilter)
        {
            ref var entity = ref damageFilter.Get1(i);
            ref var healthComponent = ref entity.target.Get<HealthComponent>();

            healthComponent.currentHealth -= entity.value;

            if (healthComponent.currentHealth <= 0)
            {
                entity.target.Get<DeathEvent>();
                Debug.Log(entity.target + " is dead");
            }
            damageFilter.GetEntity(i).Destroy();
        }
    }
}
