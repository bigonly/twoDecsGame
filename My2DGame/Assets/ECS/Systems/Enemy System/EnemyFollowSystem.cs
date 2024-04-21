using Leopotam.Ecs;

public class EnemyFollowSystem : IEcsRunSystem
{
    private EcsFilter<Enemy, Follow, AnimatorRef> followingEnemies;
    private RuntimeData runtimeData;
    private EcsWorld ecsWorld;
    public void Run()
    {
        foreach (var i in followingEnemies)
        {
            //Затычка
        }
    }
}