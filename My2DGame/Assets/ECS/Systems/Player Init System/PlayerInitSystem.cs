using Cinemachine;
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
        
        ref var player = ref playerEntity.Get<Player>();
        ref var mouseinputComponent = ref playerEntity.Get<MouseComponent>();
        ref var hasWeapon = ref playerEntity.Get<HasWeapon>();
        ref var camera = ref playerEntity.Get<CameraComponent>(); 
        ref var animationRef = ref playerEntity.Get<AnimationRef>();
        ref var transformRef = ref playerEntity.Get<TransformRef>();
        ref var directionComponent = ref playerEntity.Get<DirectionComponent>();
        ref var jumpCount = ref playerEntity.Get<MultiJumpComponent>();
        ref var jumpComponent = ref playerEntity.Get<JumpComponent>();
        ref var groundCheckBoxComponent = ref playerEntity.Get<GroundCheckBoxComponent>();
            
        GameObject playerGameObject = Object.Instantiate(   
            staticData.playerPrefab,
            sceneData.playerSpawnPoint.position,
            Quaternion.identity);

        camera.playerCamera = sceneData.playerCamera;

        Debug.Log(camera.playerCamera);
        player.playerTransform = playerGameObject.transform;
        player.playerAnimator = playerGameObject.GetComponent<Animator>();
        player.rigidbody2D = playerGameObject.GetComponent<Rigidbody2D>();
        player.speed = staticData.playerSpeed;
        player.gravity = staticData.gravity;
        
        var weaponEntity = ecsWorld.NewEntity();
        var weaponView = playerGameObject.GetComponentInChildren<WeaponSettings>();
        ref var weapon = ref weaponEntity.Get<Weapon>();
        camera.transform = weaponView.weaponSocket;
        weapon.owner = playerEntity;
        weapon.projectilePrefab = weaponView.projectilePrefab;
        weapon.projectileRadius = weaponView.projectileRadius;
        weapon.distance = weaponView.distance;
        weapon.projectileSocket = weaponView.projectileSocket;
        weapon.weaponSocket = weaponView.weaponSocket;
        weapon.projectileSpeed = weaponView.projectileSpeed;
        weapon.totalAmmo = weaponView.totalAmmo;
        weapon.weaponDamage = weaponView.weaponDamage;
        weapon.currentInMagazine = weaponView.currentInMagazine;
        weapon.maxInMagazine = weaponView.maxInMagazine;


        var playerView = playerGameObject.GetComponent<PlayerSettings>();
        var groundCheckBoxView = playerGameObject.GetComponent<GroundCheckBoxView>();
        
        groundCheckBoxComponent.groundMask = groundCheckBoxView.groundMask;
        groundCheckBoxComponent.groundCheckPosition = groundCheckBoxView.groundCheckPosition;
        groundCheckBoxComponent.boxLenght_X = groundCheckBoxView.boxLenght_X;
        groundCheckBoxComponent.boxHeight_Y = groundCheckBoxView.boxHeight_Y;

        
        jumpComponent.force = playerView.jumpForce;

        jumpCount.jumpCount = playerView.jumpCount;
        jumpCount.saveJumpCount = playerView.saveJumpCount;


        transformRef.transform = playerGameObject.transform;
        runtimeData.playerEntity = playerEntity;

        hasWeapon.weapon = weaponEntity;
        playerGameObject.GetComponent<PlayerView>().entity = playerEntity;
        animationRef.animator = player.playerAnimator;
        Debug.Log("PlayerInitSystem");
    }
}
