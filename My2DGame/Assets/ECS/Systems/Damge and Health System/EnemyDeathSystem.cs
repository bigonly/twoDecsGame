using Leopotam.Ecs;

public class EnemyDeathSystem : IEcsRunSystem
{
    private EcsFilter<Enemy, DeathEvent, AnimatorRef> deadEnemies;
    public void Run()
    {
        foreach (var i in deadEnemies)
        {
            ref var enemy = ref deadEnemies.Get1(i);
            ref var animationRef = ref deadEnemies.Get3(i);
            
            animationRef.animator.SetTrigger("Death");
            enemy.enemyPatrol.enabled = false;

            ref var entity = ref deadEnemies.GetEntity(i);
            entity.Destroy();
        }
    }
}
