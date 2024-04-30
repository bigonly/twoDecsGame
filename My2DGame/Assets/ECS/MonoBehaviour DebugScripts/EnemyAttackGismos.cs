using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackGismos : MonoBehaviour
{
    [SerializeField] private float meleeAttackDistance;
    [SerializeField] private float triggerDistance;
    [SerializeField] private BoxCollider2D boxCollider;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * meleeAttackDistance * transform.localScale.x * triggerDistance,
            new Vector3(boxCollider.bounds.size.x * meleeAttackDistance, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
}
