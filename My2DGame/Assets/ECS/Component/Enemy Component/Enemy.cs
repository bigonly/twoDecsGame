using UnityEngine;

namespace NTC.Source.Code.Ecs
{
    public struct Enemy
    {
        public Transform transform;
        public float meleeAttackDistance;
        public float triggerDistance;
        public float meleeAttackInterval;
        public float damage;
    }
}