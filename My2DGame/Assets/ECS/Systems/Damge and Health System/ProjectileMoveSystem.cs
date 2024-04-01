using Leopotam.Ecs;
using UnityEngine;


public class ProjectileMoveSystem : IEcsRunSystem
{
    private readonly EcsFilter<Projectile> filter = null;
    public void Run()
    {
        foreach (var i in filter)
        {
            ref var projectile = ref filter.Get1(i);

            var position = projectile.projectileGameObject.transform.position;
            position += projectile.direction * projectile.speed * Time.deltaTime;
            projectile.projectileGameObject.transform.position = position;

            var displacementSilenceLastFrame = position - projectile.previousPos;
            var hit = Physics.SphereCast(projectile.previousPos, projectile.radius, 
                displacementSilenceLastFrame.normalized, out var hitInfo, displacementSilenceLastFrame.magnitude);
                
            if (hit)
            {
                ref var entity = ref filter.GetEntity(i);
                ref var projectileHit = ref entity.Get<ProjectileHit>();
            }

            projectile.previousPos = projectile.projectileGameObject.transform.position;
        }
    }
}
