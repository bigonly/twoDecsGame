using Leopotam.Ecs;
using UnityEngine;

public class EnemyInitSystem : IEcsInitSystem
{
    private EcsWorld ecsWorld;
    private RuntimeData runtimeData;
    public void Init()
    {
        foreach (var enemyView in Object.FindObjectsOfType<EnemyView>())
        {
            var enemyEntity = ecsWorld.NewEntity();

            ref var enemy = ref enemyEntity.Get<Enemy>();
            ref var health = ref enemyEntity.Get<HealthComponent>();
            ref var animatorRef = ref enemyEntity.Get<AnimatorRef>();
            ref var hasWeapon = ref enemyEntity.Get<HasWeapon>();
            ref var target = ref enemyEntity.Get<Detect>();

            enemyEntity.Get<Idle>();

            health.currentHealth = enemyView.startHealth;
            health.ecsEntity = enemyEntity;

            enemy.enemyPrefab = enemyView.enemyPrefab;
            enemy.damage = enemyView.damage;
            enemy.attackDistance = enemyView.attackDistance;
            enemy.transform = enemyView.transform;
            enemy.attackInterval = enemyView.attackInterval;
            enemy.triggerDistance = enemyView.triggerDistance;
            enemy.playerLayerMask = enemyView.playerLayerMask;
            enemy.boxCollider2D = enemyView.boxCollider2D;
            enemy.enemyPatrol = enemyView.enemyPatrol;
            enemy.rangedEnemy = enemyView.rangedEnemy;
            enemy.weaponSettings = enemyView.weaponSettings;
            animatorRef.animator = enemyView.animator;

            target.target = runtimeData.playerEntity;

            var weaponEntity = ecsWorld.NewEntity();
            ref var weapon = ref weaponEntity.Get<Weapon>();
            weapon.owner = enemyEntity;
            weapon.layerMask = enemy.weaponSettings.layerMask;
            weapon.projectilePrefab = enemy.weaponSettings.projectilePrefab;
            weapon.projectileRadius = enemy.weaponSettings.projectileRadius;
            weapon.projectileSocket = enemy.weaponSettings.projectileSocket;
            weapon.weaponSocket = enemy.weaponSettings.weaponSocket;
            weapon.projectileSpeed = enemy.weaponSettings.projectileSpeed;
            weapon.totalAmmo = enemy.weaponSettings.totalAmmo;
            weapon.weaponDamage = enemy.weaponSettings.weaponDamage;
            weapon.currentInMagazine = enemy.weaponSettings.currentInMagazine;
            weapon.maxInMagazine = enemy.weaponSettings.maxInMagazine;
            if (enemy.transform.localScale.x <= -1)
            {
                weapon.weaponSocket.rotation = Quaternion.Euler(0f, 0f, 180f);
            }
            Debug.Log("EnemyInitSystem" +
                "\nEnemy Weapon View:" + enemy.weaponSettings.projectilePrefab +
                "\nEnemy Weapon Damage:" + enemy.weaponSettings.weaponDamage +
                "\nEnemy player layer Mask:" + enemy.playerLayerMask);

            hasWeapon.weapon = weaponEntity;
            enemyView.entity = enemyEntity;
        }
    }
}