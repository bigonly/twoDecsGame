using Leopotam.Ecs;
using UnityEngine;


sealed class PlayerInitSystem : IEcsInitSystem
{
    private EcsWorld ecsWorld;
    private StaticData staticData;
    private SceneData sceneData;
    private RuntimeData runtimeData;
    private UI ui;
    public void Init()
    {
        EcsEntity playerEntity = ecsWorld.NewEntity();

        ref var player = ref playerEntity.Get<Player>();
        ref var health = ref playerEntity.Get<HealthComponent>();
        ref var playerBody = ref playerEntity.Get<PlayerBody>();
        ref var mouseinputComponent = ref playerEntity.Get<MouseComponent>();
        ref var hasWeapon = ref playerEntity.Get<HasWeapon>();
        ref var weaponTransform = ref playerEntity.Get<WeaponTransform>();
        ref var camera = ref playerEntity.Get<CameraComponent>();
        ref var animationRef = ref playerEntity.Get<AnimatorRef>();
        ref var transformRef = ref playerEntity.Get<TransformRef>();
        ref var directionComponent = ref playerEntity.Get<KeyboardComponent>();
        ref var jumpCount = ref playerEntity.Get<MultiJumpComponent>();
        ref var jumpComponent = ref playerEntity.Get<JumpComponent>();
        ref var groundCheckBoxComponent = ref playerEntity.Get<GroundCheckBoxComponent>();

        GameObject playerGameObject = Object.Instantiate(
            staticData.playerPrefab,
            sceneData.playerSpawnPoint.position,
            Quaternion.identity);

        var playerBodyView = playerGameObject.GetComponent<PlayerBodyPart>();
        playerBody.body = playerBodyView.body;

        camera.playerCamera = sceneData.playerCamera;

        player.playerPrefab = playerGameObject;
        player.playerTransform = playerGameObject.transform;
        sceneData.virtualCamera.Follow = player.playerTransform.transform;
        player.playerAnimator = playerGameObject.GetComponent<Animator>();
        player.rigidbody2D = playerGameObject.GetComponent<Rigidbody2D>();
        player.speed = staticData.playerSpeed;
        player.gravity = staticData.gravity;

        var weaponEntity = ecsWorld.NewEntity();
        var weaponView = playerGameObject.GetComponentInChildren<WeaponSettings>();
        ref var weapon = ref weaponEntity.Get<Weapon>();
        camera.transform = weaponView.weaponSocket;
        weapon.owner = playerEntity;
        weapon.layerMask = weaponView.layerMask;
        weapon.projectilePrefab = weaponView.projectilePrefab;
        weapon.projectileRadius = weaponView.projectileRadius;
        weapon.projectileSocket = weaponView.projectileSocket;
        weapon.weaponSocket = weaponView.weaponSocket;
        weapon.projectileSpeed = weaponView.projectileSpeed;
        weapon.totalAmmo = weaponView.totalAmmo;
        weapon.weaponDamage = weaponView.weaponDamage;
        weapon.currentInMagazine = weaponView.currentInMagazine;
        weapon.maxInMagazine = weaponView.maxInMagazine;

        var weaponTransformView = playerGameObject.GetComponentInChildren<WeaponsTransformView>();
        weaponTransform.weaponSocket = weaponTransformView.weaponSocket;
        weaponTransform.onHandWeapon = weaponTransformView.onHandWeapon;

        var playerView = playerGameObject.GetComponent<PlayerSettings>();
        var groundCheckBoxView = playerGameObject.GetComponent<GroundCheckBoxView>();

        groundCheckBoxComponent.groundMask = groundCheckBoxView.groundMask;
        groundCheckBoxComponent.groundCheckPosition = groundCheckBoxView.groundCheckPosition;
        groundCheckBoxComponent.boxLenght_X = groundCheckBoxView.boxLenght_X;
        groundCheckBoxComponent.boxHeight_Y = groundCheckBoxView.boxHeight_Y;


        jumpComponent.force = playerView.jumpForce;

        jumpCount.jumpCount = playerView.jumpCount;
        jumpCount.saveJumpCount = playerView.saveJumpCount;

        health.currentHealth = staticData.playerHealth;
        health.ecsEntity = playerEntity;

        transformRef.transform = playerGameObject.transform;
        runtimeData.playerEntity = playerEntity;

        ui.gameScreen.SetAmmo(weapon.currentInMagazine, weapon.totalAmmo);
        ui.gameScreen.SetHealth(health.currentHealth);

        hasWeapon.weapon = weaponEntity;
        playerGameObject.GetComponent<PlayerView>().entity = playerEntity;
        animationRef.animator = player.playerAnimator;
        Debug.Log("PlayerInitSystem" +
            "\nHealth:" + health.currentHealth +
            "\nPlayer Weapon Damage:" + weapon.weaponDamage);
    }
}
