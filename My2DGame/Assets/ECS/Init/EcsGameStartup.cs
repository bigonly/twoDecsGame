using UnityEngine;
using Leopotam.Ecs;


public class EcsGameStartup : MonoBehaviour
{
    public StaticData configuration;
    public SceneData sceneData;

    private EcsWorld world;
    private EcsSystems systems;

    private void Start()
    {
        world = new EcsWorld();
        systems = new EcsSystems(world);
        RuntimeData runtimeData = new RuntimeData();
#if UNITY_EDITOR
        Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (world);
        Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (systems);
#endif                
        systems
            .Add(new LimitFPSSystem())
            .Add(new PlayerInitSystem())
            .Add(new EnemyInitSystem())
            //.Add(new HealthInitSystem())
            .OneFrame<JumpEvent>()
            .OneFrame<TryReload>()
            .Add(new PlayerMouseInputSystem())
            .Add(new WeaponRorationSystem())
            .Add(new PlayerFlipSystem())
            //.Add(new InitSavedPlayerPositionSystem())
            //.Add(new SavePlayerPositionSystem())
            //.Add(new OneWayPlatfomAvailableSystem())
            //.Add(new PlayerOneWayPlatformSystem())
            .Add(new PlayerAnimationSystem())
            .Add(new EnemyIdleSystem())
            .Add(new DamageSystem())
            .Add(new EnemyDeathSystem())
            .Add(new PlayerJumpSendEventSystem())
            .Add(new GravityCalculationSystem())
            .Add(new GroundCheckSystem())
            .Add(new MultiJumpCountSystem())
            .Add(new PlayerJumpSystem())
            .Add(new PlayerKeyboardInputSystem())
            .Add(new MovementSystem())
            .Add(new WeaponShootSystem())
            .Add(new SpawnProjectileSystem())
            .Add(new ProjectileMoveSystem())
            .Add(new ProjectileHitSystem())
            .Add(new ReloadSystem())
            .Inject(configuration)
            .Inject(sceneData)
            .Inject(runtimeData);
            
            systems.Init();
        //AddInjections();
        //AddOneFrames();
        //AddSystems();
    }

    private void Update()
    {
        systems?.Run();
    }

    private void OnDestroy()
    {
        world.Destroy();
        systems.Destroy();
    }
}
