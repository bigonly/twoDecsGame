using Leopotam.Ecs;
using UnityEngine;

public class EnemyInitSystem : IEcsInitSystem
{
    private EcsWorld _world;
    public void Init()
    {
        foreach (var enemyView in Object.FindObjectsOfType<EnemyView>())
        {
            var enemyEntity = _world.NewEntity();

            ref var enemy = ref enemyEntity.Get<Enemy>();
            ref var health = ref enemyEntity.Get<HealthComponent>();
            ref var animatorRef = ref enemyEntity.Get<AnimatorRef>();

            enemyEntity.Get<Idle>();

            health.currentHealth = enemyView.startHealth;
            Debug.Log(health.currentHealth);
            enemy.damage = enemyView.damage;
            enemy.meleeAttackDistance = enemyView.meleeAttackDistance;
            enemy.transform = enemyView.transform;
            enemy.meleeAttackInterval = enemyView.meleeAttackInterval;
            enemy.triggerDistance = enemyView.triggerDistance;
            animatorRef.animator = enemyView.animator;
            Debug.Log("EnemyInitSystem");

            enemyView.entity = enemyEntity;
        }
    }
}
