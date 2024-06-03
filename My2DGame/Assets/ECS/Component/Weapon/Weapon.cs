﻿using Leopotam.Ecs;
using UnityEngine;

public struct Weapon
{
    public EcsEntity owner;
    public LayerMask layerMask;
    public GameObject projectilePrefab;
    public Transform projectileSocket;
    public Transform weaponSocket;
    public float projectileSpeed;
    public float projectileRadius;
    public int weaponDamage;
    public int currentInMagazine;
    public int maxInMagazine;
    public int totalAmmo;
}
