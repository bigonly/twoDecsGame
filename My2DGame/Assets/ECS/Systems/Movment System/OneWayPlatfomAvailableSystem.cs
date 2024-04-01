using Leopotam.Ecs;
using UnityEngine;


sealed class OneWayPlatfomAvailableSystem : IEcsRunSystem
{
    private readonly EcsFilter<PlatformAvailabilityDurationComponent> platfomFilter = null;
    public void Run()
    {
        foreach (var i in platfomFilter)
        {
            ref var entity = ref platfomFilter.GetEntity(i);
            ref var delay = ref platfomFilter.Get1(i);

            if (!delay.IsDelayFinished)
            {
                delay.Timer += Time.deltaTime;
                if (delay.Timer >= delay.DelayDuration)
                {
                    delay.IsDelayFinished = true;
                }
            }
        }
    }
}
