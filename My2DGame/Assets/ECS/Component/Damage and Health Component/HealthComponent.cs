using Leopotam.Ecs;
using System;

[Serializable]
public struct HealthComponent
{
    public EcsEntity ecsEntity;
    public float currentHealth;
    public float maxHealth;
}