using Leopotam.Ecs;
using UnityEngine;


public class PoisonDamageSystem : IEcsRunSystem
{
    private readonly EcsFilter<PoisonDamage, DamageComponent, DamageTag> poisonDamageFilter = null;
    public void Run()
    {
        foreach (var i in poisonDamageFilter)
        {
            ref var poisonComponent = ref poisonDamageFilter.Get1(i);
            ref var damageComponent = ref poisonDamageFilter.Get2(i);
            ref var entity = ref poisonDamageFilter.GetEntity(i);

            poisonComponent.Time -= Time.deltaTime;
            if (poisonComponent.CurrnetInterval < Time.deltaTime)
            {
                poisonComponent.CurrnetInterval = Time.time + poisonComponent.Interval;
                //damageComponent.Damage = poisonComponent.DamageAmount;
            }
            if (poisonComponent.Time <= 0)
            {
                entity.Del<PoisonDamage>();
            }
        }
    }
}
