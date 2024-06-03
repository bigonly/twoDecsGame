using Leopotam.Ecs;
using UnityEngine;

public class BoneView : MonoBehaviour
{
    public EcsEntity ecsEntity;
    public LayerMask playerLayerMask;
    public Transform transform;
    public BoxCollider2D boxCollider2D; 
}