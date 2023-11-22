using System;

namespace NTC.Source.Code.Ecs
{
    [Serializable]
    public struct PoisonDamage
    {
        public float DamageAmount;
        public float Time;
        public float Interval;
        public float CurrnetInterval;
    }
}