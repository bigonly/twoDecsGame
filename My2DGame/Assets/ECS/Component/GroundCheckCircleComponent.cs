using System;
using UnityEngine;

namespace NTC.Source.Code.Ecs
{
    [Serializable]
    public struct GroundCheckCircleComponent
    {
        public LayerMask groundMask;
        public Transform groundCheckCircle;
        public float groundDistance;
        public bool isGrounded;
    }
}