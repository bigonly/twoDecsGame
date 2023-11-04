using Leopotam.Ecs;
using UnityEngine;

namespace NTC.Source.Code.Ecs
{
    sealed class OneWayPlatformSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<OneWayPlatformComponent> oneWayPlatformFilter = null;
        public void Run()
        {
            foreach (var i in oneWayPlatformFilter)
            {
                ref var entity = ref oneWayPlatformFilter.GetEntity(i);
                ref var oneWayPlatformComponent = ref oneWayPlatformFilter.Get1(i);

                ref var currentOneWayPlatform = ref oneWayPlatformComponent.currentOneWayPlatform;
                ref var currentOneWayPlatformCollider = ref oneWayPlatformComponent.boxCollider2D;

            }
        }
    }
}