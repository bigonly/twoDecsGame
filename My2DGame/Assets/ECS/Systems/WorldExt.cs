using Leopotam.Ecs;
using UnityEngine;

namespace NTC.Source.Code.Ecs
{
    public static class WorldExt
    {
        public static void SendOneWayPlatform<T>(this EcsWorld world, in T currentOneWayPlatform) where T : struct
        {
            world.NewEntity().Get<T>() = currentOneWayPlatform;
        }
        public static void SendOneWayPlatformCollider<T>(this EcsWorld world, in T boxCollider2D) where T : struct
        {
            world.NewEntity().Get<T>() = boxCollider2D;
        }
    }
}