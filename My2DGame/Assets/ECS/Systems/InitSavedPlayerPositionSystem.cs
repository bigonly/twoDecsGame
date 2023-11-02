using Leopotam.Ecs;
using UnityEngine;

namespace NTC.Source.Code.Ecs
{
    sealed class InitSavedPlayerPositionSystem : IEcsInitSystem//, IEcsRunSystem
    {
        private readonly EcsFilter<PlayerPositionDataComponent> positionFilter = null;
        public void Init()
        {
            foreach (var i in positionFilter)
            {
                ref var playerPositionData = ref positionFilter.Get1(i);
                Debug.Log("It's init");
                //Debug.Log(playerPositionData.playerPositionData.savePlayerPosition);
                if (playerPositionData.playerPositionData.savePlayerPosition)
                    playerPositionData.transform.position = playerPositionData.playerPositionData.Position;
            }
        }
    }
}