using Leopotam.Ecs;

namespace NTC.Source.Code.Ecs
{
    sealed class InitSavedPlayerPositionSystem : IEcsInitSystem
    {
        private readonly EcsFilter<PlayerPositionDataComponent> positionFilter = null;
        public void Init()
        {
            foreach (var i in positionFilter)
            {
                ref var playerPositionData = ref positionFilter.Get1(i);
                if (playerPositionData.playerPositionData.savePlayerPosition)
                    playerPositionData.transform.position = playerPositionData.playerPositionData.Position;
            }
        }
    }
}