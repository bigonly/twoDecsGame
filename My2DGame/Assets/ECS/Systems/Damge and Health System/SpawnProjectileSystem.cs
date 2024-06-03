using UnityEngine;
using Leopotam.Ecs;


public class SpawnProjectileSystem : IEcsRunSystem
{
    private readonly EcsFilter<Weapon, SpawnProjectile> filter;
    private EcsWorld ecsWorld;
        
    public void Run()
    {
        foreach (var i in filter)
        {
            ref var weapon = ref filter.Get1(i);

            var projectileGO = Object.Instantiate(weapon.projectilePrefab, weapon.projectileSocket.position, weapon.weaponSocket.rotation);
            var projectileEntity = ecsWorld.NewEntity();  
                
            ref var projectile = ref projectileEntity.Get<Projectile>();

            projectile.layerMask = weapon.layerMask;
            projectile.damage = weapon.weaponDamage;
            projectile.direction = weapon.projectileSocket.forward;
            projectile.radius = weapon.projectileRadius;
            projectile.speed = weapon.projectileSpeed;
            projectile.previousPos = projectileGO.transform.position;
            projectile.projectileGameObject = projectileGO;

            ref var entity = ref filter.GetEntity(i);
            entity.Del<SpawnProjectile>();
        }
    }
}
