using System;

namespace NTC.Source.Code.Ecs
{
    [Serializable]
    public struct HealthComponent
    {
        public float currentHealth;
        public float maxHealth;
    }
}