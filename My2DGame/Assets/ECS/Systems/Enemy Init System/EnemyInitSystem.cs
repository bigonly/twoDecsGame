using Leopotam.Ecs;
using UnityEngine;

public class EnemyInitSystem : IEcsInitSystem
{
    private EcsWorld ecsWorld;
    public void Init()
    {
        foreach (var enemyView in Object.FindObjectsOfType<EnemyView>())
        {
            var enemyEntity = ecsWorld.NewEntity();

            ref var enemy = ref enemyEntity.Get<Enemy>();
            ref var health = ref enemyEntity.Get<HealthComponent>();
            ref var animatorRef = ref enemyEntity.Get<AnimatorRef>();
            ref var hasWeapon = ref enemyEntity.Get<HasWeapon>();

            enemyEntity.Get<Idle>();

            health.currentHealth = enemyView.startHealth;
            enemy.damage = enemyView.damage;
            enemy.attackDistance = enemyView.attackDistance;
            enemy.transform = enemyView.transform;
            enemy.attackInterval = enemyView.attackInterval;
            enemy.triggerDistance = enemyView.triggerDistance;
            enemy.playerLayerMask = enemyView.playerLayerMask;
            enemy.boxCollider2D = enemyView.boxCollider2D;
            enemy.enemyPatrol = enemyView.enemyPatrol;
            enemy.rangedEnemy = enemyView.rangedEnemy;
            animatorRef.animator = enemyView.animator;

            var weaponEntity = ecsWorld.NewEntity();
            ref var weapon = ref weaponEntity.Get<Weapon>();
            foreach (var weaponView in Object.FindObjectsOfType<WeaponSettings>())
            {
                Debug.Log(weaponView);
            }
            Debug.Log("EnemyInitSystem");

            enemyView.entity = enemyEntity;
        }
    }
}
