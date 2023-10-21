using Leopotam.Ecs;
using UnityEngine;

namespace NTC.Source.Code.Ecs
{
    sealed class OneWayPlatfomAvailableSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlatformAvailabilityDuration> platfomFilter = null;
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
}