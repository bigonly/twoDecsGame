using System;
using UnityEngine;
using Leopotam.Ecs;
using Voody.UniLeo;

namespace NTC.Source.Code.Ecs
{
    public sealed class EcsGameStartup : MonoBehaviour
    {
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

        }
        private void AddSystems()
        {
            systems
                .Add(new LimitFPSSystem())
                .Add(new InitSavedPlayerPositionSystem())
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
            ;
        }
        private void AddOneFrames()
        {
            systems
                .OneFrame<JumpEvent>();
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