using UnityEngine;
using Leopotam.Ecs;
using Voody.UniLeo;


public sealed class EcsGameStartup : MonoBehaviour
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
            .ConvertScene()
            .Add(new LimitFPSSystem())
            .Add(new PlayerInitSystem())
            .Add(new HealthInitSystem())
            //.Add(new InitSavedPlayerPositionSystem())
            //.Add(new SavePlayerPositionSystem())
            .Add(new OneWayPlatfomAvailableSystem())
            .Add(new PlayerOneWayPlatformSystem())
            .Add(new PlayerJumpSendEventSystem())
            .Add(new GravityCalculationSystem())
            .Add(new GroundCheckSystem())
            .Add(new MultiJumpCountSystem())
            .Add(new PlayerJumpSystem())
            .Add(new MovementSystem())
            .Add(new PlayerKeyboardInputSystem())
            .Add(new PlayerMouseInputSystem())
            .Add(new WeaponShootSystem())
            .Add(new SpawnProjectileSystem())
            //.Add(new ProjectileMoveSystem())
            .Inject(runtimeData);
        ;

        AddInjections();
        AddOneFrames();
        //AddSystems();

        systems.Init();
    }

    private void AddInjections()
    {
        systems
            .Inject(configuration)
            .Inject(sceneData);
    }
    private void AddOneFrames()
    {
        systems
            .OneFrame<JumpEvent>()
            ;
    }

    private void Update()
    {
        systems?.Run();
    }

    private void OnDestroy()
    {
        if (systems == null) return;

        systems.Destroy();
        systems = null;
        world.Destroy();
        world = null;
    }
}
