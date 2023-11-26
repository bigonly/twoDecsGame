using Leopotam.Ecs;
using UnityEngine;

namespace NTC.Source.Code.Ecs
{
    public class DamageSystem : IEcsRunSystem
    {
        private readonly EcsFilter<HealthComponent, DamageComponent> damageFilter = null;
        private float _damage;
        public void Run()
        {
            foreach (var i in damageFilter)
            {
                ref var entity = ref damageFilter.GetEntity(i);

                //ref var damageComponent = ref entity.Get<DamageComponent>();
                ref var healthComponent = ref damageFilter.Get1(i);
                ref var damageComponent = ref damageFilter.Get2(i);
                //Debug.Log("Form Run: " + healthComponent.currentHealth);
                if (healthComponent.currentHealth <= 0)
                {
                    Debug.Log("You are Dead");
                    entity.Del<HealthComponent>();
                }
            }
        }
    }
}