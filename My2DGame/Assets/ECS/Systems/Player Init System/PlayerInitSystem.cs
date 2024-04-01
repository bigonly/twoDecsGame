using Leopotam.Ecs;
using UnityEngine;


sealed class PlayerInitSystem : IEcsInitSystem
{
    private EcsWorld ecsWorld;
    private StaticData staticData;
    private SceneData sceneData;
    private RuntimeData runtimeData;
    public void Init()
    {
        EcsEntity playerEntity = ecsWorld.NewEntity();
        
        ref var player = ref playerEntity.Get<PlayerTag>();
        ref var hasWeapon = ref playerEntity.Get<HasWeapon>();
            
        GameObject playerGameObject = Object.Instantiate(
            staticData.playerPrefab,
            sceneData.playerSpawnPoint.position,
            Quaternion.identity);

        var weaponEntity = ecsWorld.NewEntity();
        var weaponView = playerGameObject.GetComponentInChildren<WeaponSettings>();
        ref var weapon = ref weaponEntity.Get<Weapon>();
        weapon.owner = playerEntity;
        weapon.projectilePrefab = weaponView.projectilePrefab;
        weapon.projectileRadius = weaponView.projectileRadius;
        weapon.projectileSocket = weaponView.projectileSocket;
        weapon.projectileSpeed = weaponView.projectileSpeed;
        weapon.totalAmmo = weaponView.totalAmmo;
        weapon.weaponDamage = weaponView.weaponDamage;
        weapon.currentInMagazine = weaponView.currentInMagazine;
        weapon.maxInMagazine = weaponView.maxInMagazine;

        runtimeData.playerEntity = playerEntity;
        hasWeapon.weapon = weaponEntity;

        playerGameObject.GetComponent<PlayerView>().entity = playerEntity;
    }
}
