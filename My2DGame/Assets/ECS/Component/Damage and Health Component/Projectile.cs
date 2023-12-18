using UnityEngine;

namespace NTC.Source.Code.Ecs
{
    public struct Projectile
    {
        public Vector3 direction;
        public Vector3 previousPos;
        public GameObject projectileGameObject;
        public float speed;
        public float radius;
        public int damage;
    }
}