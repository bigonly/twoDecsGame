﻿using Leopotam.Ecs;
using UnityEngine;


public class WeaponShootSystem : IEcsRunSystem
{
    private EcsFilter<Weapon, Shoot> filter;
    public void Run()
    {
        foreach (var i in filter)
        {
            ref var weapon = ref filter.Get1(i);
            
            ref var entity = ref filter.GetEntity(i);
                
            //Debug.Log("WeaponShootSystem");

            if (weapon.currentInMagazine > 0)
            {
                weapon.currentInMagazine--;
                Debug.Log(weapon.currentInMagazine);
                ref var spawnProjectile = ref entity.Get<SpawnProjectile>();
                entity.Del<Shoot>();
            }
        }
    }
}