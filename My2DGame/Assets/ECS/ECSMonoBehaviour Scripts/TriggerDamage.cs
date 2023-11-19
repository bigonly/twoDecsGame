using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace NTC.Source.Code.Ecs
{
    public class TriggerDamage : MonoBehaviour
    {

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareTag("Player")) return;
            var playerEntity =
                WorldHandler.GetWorld().GetFilter(typeof(EcsFilter<PlayerTag>)).GetEntity(0);
            var enemyEntity =
                WorldHandler.GetWorld().GetFilter(typeof(EcsFilter<EnemyTag>)).GetEntity(0);

            playerEntity.Get<DamageComponent>().Damage = enemyEntity.Get<DamageComponent>().Damage;

            //Debug.Log("Hit");
        }
    }
}