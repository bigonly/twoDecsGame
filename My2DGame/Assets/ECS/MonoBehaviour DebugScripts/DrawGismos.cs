using UnityEngine;

public class DrawGismos : MonoBehaviour
{

    public Transform transform;
    public float boxLenght;
    public float boxHeight;
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector2(boxLenght, boxHeight));
    }
}
