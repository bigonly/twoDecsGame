using System;
using UnityEngine;


[Serializable]
public struct Projectile
{
    public Vector2 direction;
    public Vector2 previousPos;
    public GameObject projectileGameObject;
    public float speed;
    public float radius;
    public float distance;
    public int damage;
}