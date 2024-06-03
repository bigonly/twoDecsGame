using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;


public class EnemyDamageTrigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
    }
}
