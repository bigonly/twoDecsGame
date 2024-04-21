﻿using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UIElements;


public class ProjectileMoveSystem : IEcsRunSystem
{
    private readonly EcsFilter<Projectile> filter = null;
    public void Run()
    {
        foreach (var i in filter)
        {
            ref var projectile = ref filter.Get1(i);

            var position = projectile.projectileGameObject.transform.position;
            var radius = projectile.radius;
            var layerMask = projectile.layerMask;
            var direction = projectile.projectileGameObject.transform.right;
            projectile.projectileGameObject.transform.Translate(Vector2.right * projectile.speed * Time.deltaTime);

            var hit = Physics2D.CircleCast(position, radius, projectile.direction, 10f, layerMask);
            Debug.Log(hit);
            if (hit)
            {
                //Debug.Log("Hit");
                ref var entity = ref filter.GetEntity(i);
                ref var projectileHit = ref entity.Get<ProjectileHit>();
                projectileHit.raycastHit = hit;
            }

            //projectile.previousPos = projectile.projectileGameObject.transform.position;
        }
    }
}
