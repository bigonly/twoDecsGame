using Leopotam.Ecs;

public class PlayerAnimationSystem : IEcsRunSystem
{
    private EcsFilter<Player, MouseComponent> _filter;
    public void Run()
    {
        foreach (var i in _filter)
        {
            ref Player player = ref _filter.Get1(i);
            ref MouseComponent mouseInput = ref _filter.Get2(i);

            player.playerAnimator.SetBool("Shooting", mouseInput.leftMouseButton);
        }
    }
}