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
            //Debug.Log("Spawn Projectile");

            ref var weapon = ref filter.Get1(i);
            
            Debug.Log(weapon.projectilePrefab);
            var projectileGO = Object.Instantiate(weapon.projectilePrefab,weapon.projectileSocket.position, Quaternion.identity); 
            // weapon.projectileSocket.rotation
            var projectileEntity = ecsWorld.NewEntity();  
                
            ref var projectile = ref projectileEntity.Get<Projectile>();

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
