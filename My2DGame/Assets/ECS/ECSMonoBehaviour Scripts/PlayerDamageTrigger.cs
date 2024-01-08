using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace NTC.Source.Code.Ecs
{
    public class PlayerDamageTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareTag("Enemy")) return;
            var playerEntity =
                WorldHandler.GetWorld().GetFilter(typeof(EcsFilter<PlayerTag>)).GetEntity(0);
            var enemyEntity =
                WorldHandler.GetWorld().GetFilter(typeof(EcsFilter<EnemyTag>)).GetEntity(0);

            enemyEntity.Get<HealthComponent>().currentHealth -= playerEntity.Get<DamageComponent>().Damage;
        }
    }
}