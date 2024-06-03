using Leopotam.Ecs;
using UnityEngine;


sealed class LimitFPSSystem : IEcsInitSystem
{
    private readonly EcsWorld _world = null;
    private readonly EcsFilter<LimitFPSComponent> fpsFilter = null;
    public void Init()
    {
        foreach (var i in fpsFilter)
        {
            ref var limitFPSComponent = ref fpsFilter.Get1(i);
            ref var targetFPS = ref limitFPSComponent.targetFPS;
                
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = targetFPS;
        }
    }
}
