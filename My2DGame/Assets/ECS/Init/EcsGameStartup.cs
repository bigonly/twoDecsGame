using System;
using UnityEngine;
using Leopotam.Ecs;
using Voody.UniLeo;
using Zenject;

namespace NTC.Source.Code.Ecs
{
    public sealed class EcsGameStartup : MonoBehaviour
    {
        public SceneData sceneData;
        private EcsWorld world;
        private EcsSystems systems;

        private void Start()
        {
            world = new EcsWorld();
            systems = new EcsSystems(world);

            systems.ConvertScene();

            AddInjections();
            AddOneFrames();
            AddSystems();

            systems.Init();
        }

        private void AddInjections()
        {
            systems.Inject(sceneData);
        }
        private void AddSystems()
        {
            systems
                .Add(new LimitFPSSystem())
                .Add(new EnemyInitSystem())
                .Add(new PlayerInitSystem())
                //.Add(new InitSavedPlayerPositionSystem())
                .Add(new SavePlayerPositionSystem())
                .Add(new OneWayPlatfomAvailableSystem())
                .Add(new PlayerOneWayPlatformSystem())
                .Add(new PlayerJumpSendEventSystem())
                .Add(new GravityCalculationSystem())
                .Add(new GroundCheckSystem())
                .Add(new MultiJumpCountSystem())
                .Add(new PlayerJumpSystem())
                .Add(new PlayerInputSystem())
                .Add(new MovementSystem())
                .Add(new HealthInitSystem())
                .Add(new WeaponShootSystem())
                .Add(new SpawnProjectileSystem())
                .Add(new ProjectileMoveSystem())
                .Add(new ProjectileHitSystem())
                .Add(new ReloadSystem())
                //.Add(new DamageSystem())
            ;
        }
        private void AddOneFrames()
        {
            systems
                .OneFrame<JumpEvent>()
                .OneFrame<TryReload>();
        }

        private void Update()
        {
            systems.Run();
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
}