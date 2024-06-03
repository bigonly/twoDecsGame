using Leopotam.Ecs;

public class PlayerAnimationSystem : IEcsRunSystem
{
    private EcsFilter<Player, MouseComponent, KeyboardComponent> _filter;
    public void Run()
    {
        foreach (var i in _filter)
        {
            ref Player player = ref _filter.Get1(i);
            ref MouseComponent mouseInput = ref _filter.Get2(i);
            ref KeyboardComponent direction = ref _filter.Get3(i);

            player.playerAnimator.SetFloat("Horizontal", direction.direction.x);
            player.playerAnimator.SetBool("Shooting", mouseInput.leftMouseButton);
        }
    }
}