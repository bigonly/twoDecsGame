using Leopotam.Ecs;
using UnityEngine;

namespace NTC.Source.Code.Ecs
{
    sealed class PlayerInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        private StaticData staticData;
        private SceneData sceneData;
        public void Init()
        {
            foreach (var playerView in Object.FindObjectsOfType<PlayerView>())
            {
                
                var playerEntity = _world.NewEntity();
                var weaponEntity = _world.NewEntity();

                ref var player = ref playerEntity.Get<Player>();
                ref var health = ref playerEntity.Get<HealthComponent>();
                ref var hasWeapon = ref playerEntity.Get<HasWeapon>();
                ref var weapon = ref weaponEntity.Get<Weapon>();
                GameObject playerGameObject = Object.Instantiate(
                    _playerPrefab.playerPrefab, 
                    _playerPrefab.playerTransform.position,
                    Quaternion.identity);

                var weaponView = playerGameObject.GetComponentInChildren<WeaponSettings>();
                
                health.maxHealth = playerView.startHealth;
                player.damage = playerView.damage;

                /**Weapon code start**/
                weapon.owner = playerEntity;
                weapon.projectilePrefab = weaponView.projectilePrefab;
                weapon.projectileRadius = weaponView.projectileRadius;
                weapon.projectileSocket = weaponView.projectileSocket;
                weapon.projectileSpeed = weaponView.projectileSpeed;
                weapon.totalAmmo = weaponView.totalAmmo;
                weapon.weaponDamage = weaponView.weaponDamage;
                weapon.currentInMagazine = weaponView.currentInMagazine;
                weapon.maxInMagazine = weaponView.maxInMagazine;
                /**Weapon code end**/
            }

        }
    }
}