using Leopotam.Ecs;


public class ProjectileHitSystem : IEcsRunSystem
{
    private readonly EcsFilter<Projectile, ProjectileHit> filter = null;
    public void Run()
    {
        foreach (var i in filter)
        {
            ref var projectile = ref filter.Get1(i);

            projectile.projectileGameObject.SetActive(false);
        }
    }
}
