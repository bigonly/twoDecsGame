using Leopotam.Ecs;
using UnityEngine;

namespace NTC.Source.Code.Ecs
{
    sealed class PlayerInputSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<PlayerTag, DirectionComponent, HasWeapon, ShootComponent> directionFilter = null;
        private float moveX;
        private bool _shootButton;

        public void Run() 
        {
            SetDirection();
            Shoot();

            foreach (var i in directionFilter)
            {
                ref var directionComponent = ref directionFilter.Get2(i);
                ref var hasWeapon = ref directionFilter.Get3(i);
                ref var shootButton = ref directionFilter.Get4(i);
                ref var direction = ref directionComponent.direction;

                direction.x = moveX;
                shootButton.shootInput = _shootButton;  
                if(Input.GetKeyDown(KeyCode.R))
                {
                    ref var weapon = ref hasWeapon.weapon.Get<Weapon>();
                    if (weapon.currentInMagazine < weapon.maxInMagazine)
                    {
                        ref var entity = ref directionFilter.GetEntity(i);
                        entity.Get<TryReload>();
                    }
                }
            }
        }
        private void SetDirection()
        {
            moveX = Input.GetAxis("Horizontal");
        }
        private void Shoot()
        {
            _shootButton = Input.GetMouseButton(0);
        }
    }
}