using Leopotam.Ecs;
using UnityEngine;


sealed class PlayerOneWayPlatformSystem : IEcsRunSystem
{
    private readonly EcsWorld _world = null;
    private readonly
        EcsFilter<PlayerTag, PlayerOneWayPlatformComponent, OneWayPlatformComponent, PlatformAvailabilityDurationComponent> playerOneWayPlatformFilter = null;
    public void Run()
    {
        foreach (var i in playerOneWayPlatformFilter)
        {
            ref var entity = ref playerOneWayPlatformFilter.GetEntity(i);
            ref var playerOneWayPlatformComponent = ref playerOneWayPlatformFilter.Get2(i);
            ref var oneWayPlatformComponent = ref playerOneWayPlatformFilter.Get3(i);
            ref var delay = ref playerOneWayPlatformFilter.Get4(i);

            ref var playerCollider = ref playerOneWayPlatformComponent.playerCollider;
            ref var currentOneWayPlatform = ref oneWayPlatformComponent.currentOneWayPlatform;
            ref var currentOneWayPlatformCollider = ref oneWayPlatformComponent.boxCollider2D;

            if (Input.GetKey(KeyCode.S))
            {
                entity.Get<PlatformAvailabilityDurationComponent>().IsDelayFinished = false;
                if (currentOneWayPlatform != null && !delay.IsDelayFinished)
                {
                    Physics2D.IgnoreCollision(playerCollider, currentOneWayPlatformCollider);
                }
            }
            if (currentOneWayPlatform == null && delay.IsDelayFinished)
            {
                Physics2D.IgnoreCollision(playerCollider, currentOneWayPlatformCollider, false);
                entity.Get<PlatformAvailabilityDurationComponent>().Timer = 0;
                entity.Get<PlatformAvailabilityDurationComponent>().DelayDuration = 1f;
            }
        }
    }
}
