using UnityEngine;

public class DrawGismos : MonoBehaviour
{

    public Transform transform;
    public float boxLenght_X;
    public float boxHeight_Y;
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector2(boxLenght_X, boxHeight_Y));
    }
}
