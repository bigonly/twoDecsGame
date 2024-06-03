using System;
using UnityEngine;

public struct MovableComponent
{
    public Rigidbody2D rigidbody2D;
    public Vector2 velocity;
    public float speed;
    public float gravity;
}