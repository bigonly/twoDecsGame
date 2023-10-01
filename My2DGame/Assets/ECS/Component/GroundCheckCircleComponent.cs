using System;
using UnityEngine;

namespace NTC.Source.Code.Ecs
{
    [Serializable]
    public struct GroundCheckCircleComponent
    {
        public LayerMask groundMask;
        public Transform groundCheckPosition;
        public float boxLenght;
        public float boxHeight;
        public bool isGrounded;
    }
}