using Leopotam.Ecs;
using UnityEngine;

namespace NTC.Source.Code.Ecs
{
    public class EnemyInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        public void Init()
        {
            foreach (var i in Object.FindObjectsOfType<EnemyView>())
            {
                var enemyEntity = _world.NewEntity();

                ref var enemy = ref enemyEntity.Get<Enemy>();
                ref var health = ref enemyEntity.Get<HealthComponent>();

                health.maxHealth = i.startHealth;
                enemy.damage = i.damage;
                enemy.transform = i.transform;
            }
        }
    }
}