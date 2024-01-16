using Leopotam.Ecs;
using UnityEngine;

namespace NTC.Source.Code.Ecs
{
    sealed class PlayerMouseInputSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<PlayerTag, ShootComponent> filter = null;
        private bool leftMouseButton;
        public void Run()
        {
            ClickMouse();

            foreach (var i in filter)
            {
                ref var shootComponent = ref filter.Get2(i);
                shootComponent.shootInput = leftMouseButton;
            }
        }
        private void ClickMouse()
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Debug.Log("isShooting");
            }
        }
    }
}