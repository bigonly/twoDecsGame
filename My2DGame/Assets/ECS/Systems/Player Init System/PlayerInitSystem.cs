using Leopotam.Ecs;
using UnityEngine;

namespace NTC.Source.Code.Ecs
{
    sealed class PlayerInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        private StaticData staticData;
        public void Init()
        {
            EcsEntity playerEntity = _world.NewEntity();

            ref var hasWeapon = ref playerEntity.Get<HasWeapon>();
            ref var playerSceneData = ref playerEntity.Get<PlayerPositionDataComponent>();

            GameObject playerGO = Object.Instantiate(
                staticData.playerPrefab, playerSceneData.transform.position, Quaternion.identity);

            var weaponEntity = _world.NewEntity();
            var weaponView = playerGO.GetComponentInChildren<WeaponSettings>();
            ref var weapon = ref weaponEntity.Get<Weapon>();

        }
    }
}