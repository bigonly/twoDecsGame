using System;
using UnityEngine;


[Serializable]
public struct GroundCheckBoxComponent
{
    public LayerMask groundMask;
    public Transform groundCheckPosition;
    public float boxLenght_X;
    public float boxHeight_Y;
    public bool isGrounded;
}
