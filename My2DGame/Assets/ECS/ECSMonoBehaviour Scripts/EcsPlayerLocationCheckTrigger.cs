using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;


public class EcsPlayerLocationCheckTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        var playerEntity =
            WorldHandler.GetWorld().GetFilter(typeof(EcsFilter<PlayerTag>)).GetEntity(0);

        playerEntity.Get<PlayerPositionComponent>().playerEntered = true;
    }
}
