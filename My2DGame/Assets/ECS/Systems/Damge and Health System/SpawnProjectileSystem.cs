using UnityEngine;
using Leopotam.Ecs;

namespace NTC.Source.Code.Ecs
{
    public class SpawnProjectileSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Weapon, SpawnProjectile> filter = null;
        private EcsWorld ecsWorld;
        public void Run()
        {
            foreach (var i in filter)
            {
                ref var weapon = ref filter.Get1(i);

                var projectileGameObject = Object.Instantiate(
                    weapon.projectilePrefab, 
                    weapon.projectileSocket.position,
                    Quaternion.identity);
                var projectileEntity = ecsWorld.NewEntity();

                ref var projectile = ref projectileEntity.Get<Projectile>();

                projectile.damage = weapon.weaponDamage;
                projectile.direction = weapon.projectileSocket.forward;
                projectile.radius = weapon.projectileRadius;
                projectile.speed = weapon.projectileSpeed;
                projectile.previousPos = projectileGameObject.transform.position;
                projectile.projectileGameObject = projectileGameObject;

                ref var entity = ref filter.GetEntity(i);
                entity.Del<SpawnProjectile>();
            }
        }
    }
}