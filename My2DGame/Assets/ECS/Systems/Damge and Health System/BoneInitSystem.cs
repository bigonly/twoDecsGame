using Leopotam.Ecs;
using UnityEngine;


sealed class BoneInitSystem : IEcsInitSystem
{
    private EcsWorld ecsWorld;
    public void Init()
    {
        foreach (var boneView in Object.FindObjectsOfType<BoneView>())
        {
            var boneEntity = ecsWorld.NewEntity();
            ref var bone = ref boneEntity.Get<Bone>();

            bone.boxCollider2D = boneView.boxCollider2D;
            bone.LayerMask = boneView.playerLayerMask;
            bone.transform = boneView.transform;

            Debug.Log("BoneInitSystem\n" +
                "playerLayerMask" + bone.LayerMask +
                "\nboxCollider2D" + bone.boxCollider2D);
            
            boneView.ecsEntity = boneEntity;
        }
    }
}
