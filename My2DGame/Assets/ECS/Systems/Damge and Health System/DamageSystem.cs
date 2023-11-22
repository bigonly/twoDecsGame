using Leopotam.Ecs;
using UnityEngine;

namespace NTC.Source.Code.Ecs
{
    public class DamageSystem : IEcsRunSystem
    {
        private readonly EcsFilter<HealthComponent> damageFilter = null;
        public void Run()
        {
            foreach (var i in damageFilter)
            {
                ref var entity = ref damageFilter.GetEntity(i);

                ref var damageComponent = ref entity.Get<DamageComponent>();
                ref var healthComponent = ref damageFilter.Get1(i);
                Debug.Log("Form Run: " + healthComponent.currentHealth);

                healthComponent.currentHealth -= damageComponent.Damage;

                if (healthComponent.currentHealth <= 0)
                {
                    Debug.Log("You are Dead");
                }
                entity.Del<DamageComponent>();
            }
        }
    }
}