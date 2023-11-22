using Leopotam.Ecs;
using UnityEngine;

namespace NTC.Source.Code.Ecs
{
    sealed class HealthInitSystem : IEcsInitSystem
    {
        private readonly EcsFilter<HealthComponent> healthFilter = null;
        public void Init()
        {
            foreach (var i in healthFilter)
            {
                ref var entity = ref healthFilter.GetEntity(i);
                ref var healthComponent = ref healthFilter.Get1(i);

                healthComponent.currentHealth = healthComponent.maxHealth;
                Debug.Log("From Init: " + healthComponent.currentHealth);
            }
        }
    }
}