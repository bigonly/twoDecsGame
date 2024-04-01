using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;


public class EnemyDamageTrigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        var playerEntity =
            WorldHandler.GetWorld().GetFilter(typeof(EcsFilter<PlayerTag>)).GetEntity(0);
        var enemyEntity =
            WorldHandler.GetWorld().GetFilter(typeof(EcsFilter<EnemyTag>)).GetEntity(0);

        playerEntity.Get<HealthComponent>().currentHealth -= enemyEntity.Get<DamageComponent>().Damage;
    }
}
