using Leopotam.Ecs;
using UnityEngine;

public class PlayerFlipSystem : IEcsRunSystem
{
    private EcsFilter<PlayerBody, WeaponTransform> filter;
    public void Run()
    {
        foreach (var i in filter)
        {
            ref var playerBody = ref filter.Get1(i);
            ref var weaponTransform = ref filter.Get2(i);
            //Vector3 scaler = player.playerTransform.localScale;
            //Debug.Log(player.playerTransform.localScale);
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - weaponTransform.weaponSocket.position;
            float rotZ = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
            //Debug.Log(rotZ);
            if ((0 > rotZ || 0 < rotZ) && !(-90 < rotZ) || !(90 > rotZ))
            {
                //Debug.Log("-1");
                playerBody.body.transform.localScale = new Vector3(-1, 1, 1);
                weaponTransform.onHandWeapon.transform.localScale = new Vector3(1, -1, 1);
            }
            else if (90 > rotZ || -90 < rotZ)
            {
                //Debug.Log("1");
                playerBody.body.transform.localScale = new Vector3(1, 1, 1);
                weaponTransform.onHandWeapon.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}