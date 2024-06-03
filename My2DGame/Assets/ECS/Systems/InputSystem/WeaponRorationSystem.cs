using Cinemachine;
using Leopotam.Ecs;
using UnityEngine;

public class WeaponRorationSystem : IEcsRunSystem
{
    private EcsFilter<WeaponTransform> filter;
    private RuntimeData runtimeData;
    private float offset = 0;
    public void Run()
    {
        if (runtimeData.isPaused) return;
        foreach (var i in filter)
        {
            ref var weaponTransform = ref filter.Get1(i);
            
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - weaponTransform.weaponSocket.position;
            float rotZ = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
            weaponTransform.weaponSocket.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        }
    }
}
