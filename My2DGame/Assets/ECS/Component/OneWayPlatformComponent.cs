using System;
using UnityEngine;

namespace NTC.Source.Code.Ecs
{
    [Serializable]
    public struct OneWayPlatformComponent
    {
        public BoxCollider2D boxCollider2D;
        public GameObject currentOneWayPlatform;
    }
}