using Cinemachine;
using Leopotam.Ecs;
using UnityEngine;

public class WeaponRorationSystem : IEcsRunSystem
{
    private EcsFilter<Weapon> filter;
    private SceneData sceneData;
    public void Run()
    {
        foreach (var i in filter)
        {
            ref var weapon = ref filter.Get1(i);

            //Plane weaponPlane = new Plane(Vector2.left, weapon.weaponSocket.position);
            //Ray ray = sceneData.playerCamera.ScreenPointToRay(Input.mousePosition);
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 1;
            //mousePosition.z = sceneData.playerCamera.transform.position.z;
            sceneData.playerCamera.ScreenToWorldPoint(mousePosition);
            float rotZ = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
            weapon.weaponSocket.rotation = Quaternion.Euler(0, 0, rotZ);
            /**
            Vector3 aimDirection = (mousePosition - weapon.weaponSocket.position).normalized;
            float angle = Mathf.Atan2(aimDirection.x, aimDirection.y) * Mathf.Rad2Deg;
            weapon.weaponSocket.eulerAngles = new Vector3(0, 0, angle);
            Debug.Log(angle);
            //if (!weaponPlane.Raycast(ray, out var hitDistance)) continue;**/

            //weapon.weaponSocket.forward = ray.GetPoint(hitDistance) - weapon.weaponSocket.position; 
        }
    }
}