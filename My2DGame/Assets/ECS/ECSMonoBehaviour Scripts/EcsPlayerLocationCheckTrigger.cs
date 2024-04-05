using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;


public class EcsPlayerLocationCheckTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
    }
}
