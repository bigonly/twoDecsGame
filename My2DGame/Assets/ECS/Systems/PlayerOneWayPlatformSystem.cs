﻿using Leopotam.Ecs;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

namespace NTC.Source.Code.Ecs
{
    sealed class PlayerOneWayPlatformSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<PlayerTag, PlayerOneWayPlatformComponent, OneWayPlatformComponent> playerOneWayPlatformFilter = null;
        public void Run()
        {
            foreach (var i in playerOneWayPlatformFilter)
            {
                ref var entity = ref playerOneWayPlatformFilter.GetEntity(i);
                ref var playerOneWayPlatformComponent = ref playerOneWayPlatformFilter.Get2(i);
                ref var oneWayPlatformComponent = ref playerOneWayPlatformFilter.Get3(i);

                ref var playerCollider = ref playerOneWayPlatformComponent.playerCollider;
                ref var currentOneWayPlatform = ref oneWayPlatformComponent.currentOneWayPlatform;
                ref var currentOneWayPlatformCollider = ref oneWayPlatformComponent.boxCollider2D;
                if (Input.GetKeyDown(KeyCode.S))
                {
                    if (currentOneWayPlatform != null)
                    {
                        Physics2D.IgnoreCollision(playerCollider, currentOneWayPlatformCollider);
                        //Physics2D.IgnoreCollision(playerCollider, currentOneWayPlatformCollider, false);
                    }
                }
            }
        }
    }
}