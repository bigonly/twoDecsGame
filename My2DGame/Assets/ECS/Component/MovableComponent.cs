using System;
using UnityEngine;

namespace NTC.Source.Code.Ecs
{
    [Serializable]
    public struct MovableComponent
    {
 
        public Rigidbody2D rigidbody2D;
        public Vector2 velocity;
        public float speed;
        public float gravity;
    }
}