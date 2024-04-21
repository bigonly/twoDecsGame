using UnityEngine;

public struct Projectile
{
    public LayerMask layerMask;
    public Vector2 direction;
    public Vector2 previousPos;
    public GameObject projectileGameObject;
    public float speed;
    public float radius;
    public float distance;
    public int damage;
}
