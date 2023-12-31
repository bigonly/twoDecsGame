﻿using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace NTC.Source.Code.Ecs
{
    public class EcsPlayerOneWayPlatformCollision : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!collision.gameObject.CompareTag("OneWayPlatform")) return;
            var playerEntity =
                WorldHandler.GetWorld().GetFilter(typeof(EcsFilter<PlayerTag>)).GetEntity(0);
            
            playerEntity.Get<OneWayPlatformComponent>().currentOneWayPlatform = collision.gameObject;
            playerEntity.Get<OneWayPlatformComponent>().boxCollider2D = collision.gameObject.GetComponent<BoxCollider2D>();
        }
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (!collision.gameObject.CompareTag("OneWayPlatform")) return;
            var playerEntity =
                WorldHandler.GetWorld().GetFilter(typeof(EcsFilter<PlayerTag>)).GetEntity(0);
            
            playerEntity.Get<OneWayPlatformComponent>().currentOneWayPlatform = null;
        }
    }
}