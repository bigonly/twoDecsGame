using Leopotam.Ecs;
using UnityEngine;

namespace NTC.Source.Code.Ecs
{
    sealed class SavePlayerPositionSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerPositionComponent, PlayerPositionDataComponent> positionFilter = null;
        public void Run()
        {
            foreach (var i in positionFilter)
            {
                ref var entity = ref positionFilter.GetEntity(i);
                ref var playerPosition = ref positionFilter.Get1(i);
                ref var playerPositionData = ref positionFilter.Get2(i);
                Debug.Log("It's run");
                if (playerPosition.playerEntered)
                    playerPositionData.playerPositionData.savePlayerPosition = true;
                
                entity.Del<PlayerPositionComponent>();
            }
        }
    }
}